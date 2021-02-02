using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        public int Point;
        private Material _material;
        private float _lengthFly;
        private DisplayBonuses _displayBonuses;
        private GoodBonus[] _goodBonus;

        public delegate void EventUseObject();
        public event EventUseObject _useObject;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 3.0f);
            _displayBonuses = new DisplayBonuses();
        }

        protected override void Interaction()
        {
            //base.Interaction();
            _displayBonuses.Display(Point);
            _goodBonus = FindObjectsOfType<GoodBonus>();
            _useObject?.Invoke();
            //print(_goodBonus.Length);
            if (_goodBonus.Length <= 1)
            {
                print("победа");
            }
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
