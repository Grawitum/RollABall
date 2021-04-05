using UnityEngine;

namespace RollABall
{
    public sealed class BadSpeedBonus : InteractiveObject, IMove
    {
        private float _speedRotation;
        private float _lengthFly;
        private PlayerBall _playerBall;

        private void Awake()
        {
            _speedRotation = Random.Range(10.0f, 50.0f);
            _lengthFly = Random.Range(1.0f, 3.0f);
            base.FindPlayer();
        }

        protected override void Interaction()
        {
            if(_playerBall == null)
            {
                _playerBall = base.FindPlayer();
            }
            _playerBall.Speed -= 1.0f;
        }
  
        public void Move()
        {
            base.Fly(_lengthFly);
            base.Rotation(_speedRotation);
        }
    }
}