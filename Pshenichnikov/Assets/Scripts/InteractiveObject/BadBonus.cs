using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class BadBonus : UseBonus, IMove
    {
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        private float _lengthFly;
        private float _speedRotation;
        private PlayerBall _playerBall;

        private void Awake()
        {
            
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _playerBall = base.FindPlayer();
        }

        protected override void Interaction()
        {
            if (!_playerBall.Immortality)
            {
                OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            }
            else
            {
                print($"Immortality");
            }
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Rotation(_speedRotation);
        }
    }
}
