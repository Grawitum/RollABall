using System;
using UnityEngine;
using static UnityEngine.Random;

namespace RollABall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };
        private Material _material;
        private float _lengthFly;

        [Tooltip("path")]
        [SerializeField] public string path;


        //private DisplayBonuses _displayBonuses;
        //private GoodBonus[] _goodBonus;

        //public delegate void EventUseObject();
        //public event EventUseObject _useObject;

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

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }


        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
