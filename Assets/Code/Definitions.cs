﻿using System.Collections.Generic;

namespace MinimalMiner
{
    public static class Definitions
    {
        public static Dictionary<ItemMaterial, float> ItemValues
        {
            get
            {
                return new Dictionary<ItemMaterial, float>
                {
                    #region Alpha 1.3.0
                    { ItemMaterial.rock,        1f },
                    { ItemMaterial.ice,         1f },
                    { ItemMaterial.diamond,     1f },
                    { ItemMaterial.carbon,      1f },
                    { ItemMaterial.nickel,      1f },
                    { ItemMaterial.lithium,     1f },
                    { ItemMaterial.phosphorus,  1f },
                    { ItemMaterial.antimony,    1f },
                    { ItemMaterial.zinc,        1f },
                    { ItemMaterial.tin,         1f },
                    { ItemMaterial.lead,        1f },
                    { ItemMaterial.indium,      1f },
                    { ItemMaterial.silver,      1f },
                    { ItemMaterial.gold,        1f },
                    { ItemMaterial.copper,      1f },
                    { ItemMaterial.platinum,    1f },
                    { ItemMaterial.cobalt,      1f },
                    { ItemMaterial.iron,        1f },
                    { ItemMaterial.osmium,      1f },
                    { ItemMaterial.uranium,     1f },
                    { ItemMaterial.thorium,     1f },
                    { ItemMaterial.olivine,     1f },
                    { ItemMaterial.garnet,      1f },
                    { ItemMaterial.zircon,      1f },
                    { ItemMaterial.topaz,       1f },
                    { ItemMaterial.feldspar,    1f },
                    { ItemMaterial.titanite,    1f },
                    { ItemMaterial.hemimorphite,1f },
                    { ItemMaterial.osumilite,   1f },
                    { ItemMaterial.rhodonite,   1f },
                    { ItemMaterial.mica,        1f },
                    { ItemMaterial.chlorite,    1f },
                    { ItemMaterial.quartz,      1f }
                    #endregion
                };
            }
        }

        public static Dictionary<ItemMaterial, float> ItemWeights
        {
            get
            {
                return new Dictionary<ItemMaterial, float>
                {
                    #region Alpha 1.3.0
                    { ItemMaterial.rock,            1f },
                    { ItemMaterial.ice,             1f },
                    { ItemMaterial.diamond,         1f },
                    { ItemMaterial.carbon,          1f },
                    { ItemMaterial.nickel,          1f },
                    { ItemMaterial.lithium,         1f },
                    { ItemMaterial.phosphorus,      1f },
                    { ItemMaterial.antimony,        1f },
                    { ItemMaterial.zinc,            1f },
                    { ItemMaterial.tin,             1f },
                    { ItemMaterial.lead,            1f },
                    { ItemMaterial.indium,          1f },
                    { ItemMaterial.silver,          1f },
                    { ItemMaterial.gold,            1f },
                    { ItemMaterial.copper,          1f },
                    { ItemMaterial.platinum,        1f },
                    { ItemMaterial.cobalt,          1f },
                    { ItemMaterial.iron,            1f },
                    { ItemMaterial.osmium,          1f },
                    { ItemMaterial.uranium,         1f },
                    { ItemMaterial.thorium,         1f },
                    { ItemMaterial.olivine,         1f },
                    { ItemMaterial.garnet,          1f },
                    { ItemMaterial.zircon,          1f },
                    { ItemMaterial.topaz,           1f },
                    { ItemMaterial.feldspar,        1f },
                    { ItemMaterial.titanite,        1f },
                    { ItemMaterial.hemimorphite,    1f },
                    { ItemMaterial.osumilite,       1f },
                    { ItemMaterial.rhodonite,       1f },
                    { ItemMaterial.mica,            1f },
                    { ItemMaterial.chlorite,        1f },
                    { ItemMaterial.quartz,          1f }
                    #endregion
                };
            }
        }

        public static Dictionary<ItemMaterial, float> ItemDropWeights
        {
            get
            {
                return new Dictionary<ItemMaterial, float>
                {
                    #region Alpha 1.3.0
                    { ItemMaterial.rock,            1f },
                    { ItemMaterial.ice,             1f },
                    { ItemMaterial.diamond,         1f },
                    { ItemMaterial.carbon,          1f },
                    { ItemMaterial.nickel,          1f },
                    { ItemMaterial.lithium,         1f },
                    { ItemMaterial.phosphorus,      1f },
                    { ItemMaterial.antimony,        1f },
                    { ItemMaterial.zinc,            1f },
                    { ItemMaterial.tin,             1f },
                    { ItemMaterial.lead,            1f },
                    { ItemMaterial.indium,          1f },
                    { ItemMaterial.silver,          1f },
                    { ItemMaterial.gold,            1f },
                    { ItemMaterial.copper,          1f },
                    { ItemMaterial.platinum,        1f },
                    { ItemMaterial.cobalt,          1f },
                    { ItemMaterial.iron,            1f },
                    { ItemMaterial.osmium,          1f },
                    { ItemMaterial.uranium,         1f },
                    { ItemMaterial.thorium,         1f },
                    { ItemMaterial.olivine,         1f },
                    { ItemMaterial.garnet,          1f },
                    { ItemMaterial.zircon,          1f },
                    { ItemMaterial.topaz,           1f },
                    { ItemMaterial.feldspar,        1f },
                    { ItemMaterial.titanite,        1f },
                    { ItemMaterial.hemimorphite,    1f },
                    { ItemMaterial.osumilite,       1f },
                    { ItemMaterial.rhodonite,       1f },
                    { ItemMaterial.mica,            1f },
                    { ItemMaterial.chlorite,        1f },
                    { ItemMaterial.quartz,          1f }
                    #endregion
                };
            }
        }

        /// <summary>
        /// Associates all item materials with categories
        /// </summary>
        public static Dictionary<ItemMaterial, ItemCategory> ItemCategories
        {
            get
            {
                return new Dictionary<ItemMaterial, ItemCategory>
                {
                    #region Alpha 1.3.0
                    { ItemMaterial.rock,            ItemCategory.RawGeneric },
                    { ItemMaterial.ice,             ItemCategory.RawGeneric },
                    { ItemMaterial.diamond,         ItemCategory.RawGeneric },
                    { ItemMaterial.carbon,          ItemCategory.RawElement },
                    { ItemMaterial.nickel,          ItemCategory.RawElement },
                    { ItemMaterial.lithium,         ItemCategory.RawElement },
                    { ItemMaterial.phosphorus,      ItemCategory.RawElement },
                    { ItemMaterial.antimony,        ItemCategory.RawElement },
                    { ItemMaterial.zinc,            ItemCategory.RawElement },
                    { ItemMaterial.tin,             ItemCategory.RawElement },
                    { ItemMaterial.lead,            ItemCategory.RawElement },
                    { ItemMaterial.indium,          ItemCategory.RawElement },
                    { ItemMaterial.silver,          ItemCategory.RawElement },
                    { ItemMaterial.gold,            ItemCategory.RawElement },
                    { ItemMaterial.copper,          ItemCategory.RawElement },
                    { ItemMaterial.platinum,        ItemCategory.RawElement },
                    { ItemMaterial.cobalt,          ItemCategory.RawElement },
                    { ItemMaterial.iron,            ItemCategory.RawElement },
                    { ItemMaterial.osmium,          ItemCategory.RawElement },
                    { ItemMaterial.uranium,         ItemCategory.RawElement },
                    { ItemMaterial.thorium,         ItemCategory.RawElement },
                    { ItemMaterial.olivine,         ItemCategory.RawSilicate },
                    { ItemMaterial.garnet,          ItemCategory.RawSilicate },
                    { ItemMaterial.zircon,          ItemCategory.RawSilicate },
                    { ItemMaterial.topaz,           ItemCategory.RawSilicate },
                    { ItemMaterial.feldspar,        ItemCategory.RawSilicate },
                    { ItemMaterial.titanite,        ItemCategory.RawSilicate },
                    { ItemMaterial.hemimorphite,    ItemCategory.RawSilicate },
                    { ItemMaterial.osumilite,       ItemCategory.RawSilicate },
                    { ItemMaterial.rhodonite,       ItemCategory.RawSilicate },
                    { ItemMaterial.mica,            ItemCategory.RawSilicate },
                    { ItemMaterial.chlorite,        ItemCategory.RawSilicate },
                    { ItemMaterial.quartz,          ItemCategory.RawSilicate }
                    #endregion
                };
            }
        }
    }
}
