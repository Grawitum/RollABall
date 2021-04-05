using System;
using UnityEngine;
using static UnityEngine.Random;

namespace RollABall
{
    public sealed class GoodBonus : InteractiveObject, IMove
    {
        private int _point;
        public event Action<int> OnPointChange = delegate (int i) { };
        private Material _material;
        private float _lengthFly;

        [Tooltip("path")]
        [SerializeField] public string path;

        private void Awake()
        {
            _point = Range(1, 6);
            _material = GetComponent<Renderer>().material;
            _lengthFly = Range(1.0f, 5.0f);
        }

        protected override void Interaction()
        {
            OnPointChange.Invoke(_point);
        }

        public int Point()
        {
            return _point;
        }

        public void Move()
        {
            base.Fly(_lengthFly);
            base.Flicker(_material);
        }
    }
}
