﻿using UnityEngine;

namespace RollABall
{
    public class ImmortalityBonus : InteractiveObject, IMove
    {
        private Material _material;
        private float _lengthFly;
        private PlayerBall playerBall;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 3.0f);
            FindPlayer();
        }

        protected override void Interaction()
        {
            if (playerBall == null)
            {
                playerBall = base.FindPlayer();
            }
            playerBall.Immortality = true;
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Flicker(_material);
        }
    }
}
