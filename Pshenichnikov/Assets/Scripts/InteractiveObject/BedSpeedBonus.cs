using UnityEngine;

namespace RollABall
{
    public sealed class BadSpeedBonus : InteractiveObject, IMove
    {
        private float _speedRotation;
        private float _lengthFly;
        private PlayerBall playerBall;

        private void Awake()
        {
            _speedRotation = Random.Range(10.0f, 50.0f);
            _lengthFly = Random.Range(1.0f, 3.0f);
            FindPlayer();
        }

        protected override void Interaction()
        {
            if(playerBall == null)
            {
                playerBall = base.FindPlayer();
            }
            playerBall.Speed -= 1.0f;
        }
  
        public void Move()
        {
            base.Fly(_lengthFly);
            base.Rotation(_speedRotation);
        }
    }
}