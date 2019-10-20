﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimalMiner.Util;

namespace MinimalMiner.Entity
{
    public class Bullet : MonoBehaviour
    {
        public Vector3 Vel
        {
            get; private set;
        }

        private float aliveTimer;
        private GameState currState;
        [SerializeField] private SpriteRenderer sprite;

        private void OnEnable()
        {
            EventManager.onUpdateGameState += UpdateGameState;
        }

        private void OnDisable()
        {
            EventManager.onUpdateGameState -= UpdateGameState;
        }

        private void Update()
        {
            if (currState == GameState.play)
            {
                transform.position += Vel;

                // Increment timer and destroy object when object has existed for longer than 3 seconds
                aliveTimer += Time.deltaTime;
                if (aliveTimer > 3f)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void UpdateGameState(GameState newState, GameState prevState)
        {
            currState = newState;
        }
    }
}