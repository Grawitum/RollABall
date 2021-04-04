using System;
using UnityEngine;
using static UnityEngine.Random;

namespace RollABall
{
    public sealed class GoodBonus : InteractiveObject, IMove
    {
        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };
        private Material _material;
        private float _lengthFly;

        [Tooltip("path")]
        [SerializeField] public string path;

        private void Awake()
        {
            Point = Range(1, 6);
            _material = GetComponent<Renderer>().material;
            _lengthFly = Range(1.0f, 5.0f);
        }

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Flicker(_material);
        }
    }
}
