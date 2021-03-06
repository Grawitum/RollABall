﻿using UnityEngine;

namespace RollABall
{
    public class ImmortalityBonus : InteractiveObject, IMove
    {
        private Material _material;
        private float _lengthFly;
        private PlayerBall _playerBall;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 3.0f);
            _playerBall = base.FindPlayer();
        }

        protected override void Interaction()
        {
            _playerBall.Immortality = true;
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Flicker(_material);
        }
    }
}
