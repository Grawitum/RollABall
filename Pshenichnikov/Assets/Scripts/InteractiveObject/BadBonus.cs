﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        private float _lengthFly;
        private float _speedRotation;

        //private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        //public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        //{
        //    add { _caughtPlayer += value; }
        //    remove { _caughtPlayer -= value; }
        //}

        //public delegate void CaughtPlayerChange(object value);
        //private event CaughtPlayerChange _caughtPlayer;
        //public event CaughtPlayerChange CaughtPlayer
        //{
        //    add { _caughtPlayer += value; }
        //    remove { _caughtPlayer -= value; }
        //}


        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Flay();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

    }
}
