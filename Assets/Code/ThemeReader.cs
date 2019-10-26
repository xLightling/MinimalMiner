﻿#pragma warning disable 0618

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Unity.VectorGraphics;
using UnityEngine;
using TextureScale;

namespace MinimalMiner
{
    /// <summary>
    /// Handles the reading of theme files (written in XML format)
    /// </summary>
    public static class ThemeReader
    {
        /// <summary>
        /// Reads from a specified file and returns a Theme object
        /// </summary>
        /// <param name="file">The .theme file</param>
        /// <returns>The Theme data stored in the file</returns>
        public static Theme GetTheme(FileInfo file)
        {
            // IO stuff
            StreamReader reader = null;
            StringReader sr = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;

            // Needed for creating theme to return
            Theme theme;
            Type type = typeof(Theme);
            try
            {
                // Read the file
                reader = new StreamReader(file.OpenRead());
                string data = reader.ReadToEnd();
                sr = new StringReader(data);

                // Deserialize the file
                serializer = new XmlSerializer(type);
                xmlReader = new XmlTextReader(sr);
                theme = (Theme)serializer.Deserialize(xmlReader);

                // Assign sprites and return theme
                theme = AssignSprites(theme);

                // TO-DO: only assign sprites on a selected theme

                return theme;
            }

            catch (Exception e)
            {
                MonoBehaviour.print(e.Message);
            }

            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
                if (sr != null)
                    sr.Close();
                if (reader != null)
                    reader.Close();
            }

            return new Theme("undefined");
        }

        /// <summary>
        /// Creates a sprite stored at the specified theme directory, to be used for assigning sprites to a theme
        /// </summary>
        /// <param name="themeName">The name of the theme (for path)</param>
        /// <param name="spriteName">The name of the sprite</param>
        /// <param name="spriteType">The sprite type (for import method)</param>
        /// <returns>The sprite found</returns>
        public static Sprite GetSprite(string themeName, string spriteName, SpriteImportType spriteType)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath + "/Themes/" + themeName);
            FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            Sprite sprite = null;
            foreach (FileInfo file in files)
            {
                if (Path.GetFileNameWithoutExtension(file.Name) == spriteName && !file.Name.Contains("meta"))
                {
                    int size = DetermineSize(spriteName);
                    Texture2D newTex = null;
                    switch (spriteType)
                    {
                        case SpriteImportType.svg:
                        case SpriteImportType.svggradient:
                            newTex = ImportVector(file, size, spriteType);
                            sprite = Sprite.Create(newTex, new Rect(new Vector2(), new Vector2(size, size)), new Vector2(0.5f, 0.5f), size * 2);
                            break;
                        case SpriteImportType.png:
                        default:
                            newTex = ImportRaster(file, size);
                            sprite = Sprite.Create(newTex, new Rect(new Vector2(), new Vector2(size, size)), new Vector2(0.5f, 0.5f), size * 2);
                            break;
                    }
                }
            }

            return sprite;
        }

        /// <summary>
        /// Creates sprites stored at the specified theme directory, to be used for assigning sprites to a theme
        /// </summary>
        /// <param name="themeName">The name of the theme (for path)</param>
        /// <param name="spriteName">The name of the sprite</param>
        /// <param name="spriteType">The sprite type (for import method)</param>
        /// <returns>The sprites found</returns>
        public static List<Sprite> GetSprites(string themeName, string spriteName, SpriteImportType spriteType)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath + "/Themes/" + themeName);
            FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            List<Sprite> sprites = new List<Sprite>();
            foreach (FileInfo file in files)
            {
                if (file.Name.Contains(spriteName) && !file.Name.Contains("meta"))
                {
                    int size = DetermineSize(spriteName);
                    Texture2D newTex = null;
                    switch(spriteType)
                    {
                        case SpriteImportType.svg:
                        case SpriteImportType.svggradient:
                            newTex = ImportVector(file, size, spriteType);
                            sprites.Add(Sprite.Create(newTex, new Rect(new Vector2(), new Vector2(size, size)), new Vector2(0.5f, 0.5f), size * 2));
                            break;
                        case SpriteImportType.png:
                        default:
                            newTex = ImportRaster(file, size);
                            sprites.Add(Sprite.Create(newTex, new Rect(new Vector2(), new Vector2(size, size)), new Vector2(0.5f, 0.5f), size * 2));
                            break;
                    }
                }
            }

            return sprites;
        }

        /// <summary>
        /// Imports a raster (Texture2D) texture
        /// </summary>
        /// <param name="file">The file to import from</param>
        /// <param name="size">The size of the texture</param>
        /// <returns></returns>
        public static Texture2D ImportRaster(FileInfo file, int size)
        {
            // WWW is obsolete, needs replaced eventually
            WWW www = new WWW(file.FullName);
            Texture2D tex = www.texture;
            tex.alphaIsTransparency = true;

            Texture2D newTex = MonoBehaviour.Instantiate(tex);
            TextureScaler.Bilinear(newTex, size, size);

            return newTex;
        }

        /// <summary>
        /// Imports a vector (Sprite) texture
        /// </summary>
        /// <param name="file">The file to import from</param>
        /// <param name="size">The size of the texture</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Texture2D ImportVector(FileInfo file, int size, SpriteImportType type)
        {
            StreamReader reader = null;
            StringReader sr = null;
            try
            {
                reader = new StreamReader(file.OpenRead());
                sr = new StringReader(reader.ReadToEnd());
                SVGParser.SceneInfo scene = SVGParser.ImportSVG(sr);

                VectorUtils.TessellationOptions tessOptions = new VectorUtils.TessellationOptions()
                {
                    StepDistance = 100.0f,
                    MaxCordDeviation = 0.5f,
                    MaxTanAngleDeviation = 0.1f,
                    SamplingStepSize = 0.01f
                };

                List<VectorUtils.Geometry> geoms = VectorUtils.TessellateScene(scene.Scene, tessOptions);
                Sprite sprite = VectorUtils.BuildSprite(geoms, size, VectorUtils.Alignment.Center, Vector2.zero, 64, false);
                Shader shader = null;

                switch(type)
                {
                    case SpriteImportType.svggradient:
                        shader = Shader.Find("Unlit/VectorGradient");
                        break;
                    case SpriteImportType.svg:
                    default:
                        shader = Shader.Find("Unlit/Vector");
                        break;
                }

                Texture2D tex = VectorUtils.RenderSpriteToTexture2D(sprite, size, size, new Material(shader));
                tex.alphaIsTransparency = true;

                Texture2D newTex = MonoBehaviour.Instantiate(tex);
                TextureScaler.Bilinear(newTex, size, size);

                return newTex;
            }

            catch (Exception e)
            {
                MonoBehaviour.print(e.Message);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                if (sr != null)
                    sr.Close();
            }

            return null;
        }

        /// <summary>
        /// Determines the size of a texture (themes use specific set sizes when importing textures)
        /// </summary>
        /// <param name="spriteName">The sprite being imported</param>
        /// <returns></returns>
        public static int DetermineSize(string spriteName)
        {
            switch (spriteName)
            {
                // Backgrounds are 2048px in size
                case "background":
                    return 2048;

                // Asteroids, player ship, and other unspecified sprites are 512px in size
                case "asteroid":
                case "player":
                default:
                    return 512;
            }
        }

        /// <summary>
        /// Determines the SpriteImportType that a certain sprite is to be loaded with
        /// </summary>
        /// <param name="spriteName">The name of the sprite being imported</param>
        /// <param name="theme">Reference to the current theme being checked</param>
        /// <returns></returns>
        public static SpriteImportType DetermineSprite(string spriteName, Theme theme)
        {
            switch (spriteName)
            {
                case "asteroid":
                    return (SpriteImportType)theme.import_Asteroids;
                case "background":
                    return (SpriteImportType)theme.import_Backgrounds;
                case "playerShip":
                    return (SpriteImportType)theme.import_Player;
            }

            return SpriteImportType.svg;
        }

        /// <summary>
        /// Assigns sprites to a theme
        /// </summary>
        /// <param name="theme">The theme to edit and assign sprites to</param>
        /// <returns>The theme that was edited</returns>
        /// <remarks>This should only be called on an active theme to prevent overusage of memory</remarks>
        public static Theme AssignSprites(Theme theme)
        {
            theme.img_backgroundNormal = GetSprite(theme.themeName, ThemeFileName.backgroundNormal.ToString(), 
                DetermineSprite(ThemeFileName.backgroundNormal.ToString(), theme));

            theme.spriteImage_asteroid = GetSprites(theme.themeName, ThemeFileName.asteroid.ToString(), 
                DetermineSprite(ThemeFileName.backgroundNormal.ToString(), theme));

            theme.spriteImage_player = GetSprite(theme.themeName, ThemeFileName.playerShip.ToString(), 
                DetermineSprite(ThemeFileName.backgroundNormal.ToString(), theme));

            return theme;
        }
    }
}