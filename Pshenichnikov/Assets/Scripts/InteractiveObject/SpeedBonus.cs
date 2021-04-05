using UnityEngine;

namespace RollABall
{
    public sealed class SpeedBonus : InteractiveObject, IMove
    {
        private Material _material;
        private float _lengthFly;
        private PlayerBall _playerBall;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 3.0f);
            base.FindPlayer();
        }

        protected override void Interaction()
        {
            if (_playerBall == null)
            {
                _playerBall = base.FindPlayer();
            }
            _playerBall.Speed += 1;
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Flicker(_material);
        }
    }
}
