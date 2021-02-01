using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IExecute;
    {
        protected Color _color;
        public bool IsInteractable { get; } = true;

        //private event EventHandler<CaughtPlayerEventArgs> _useObject;
        //public event EventHandler<CaughtPlayerEventArgs> UseObject
        //{
        //    add { _useObject += value; }
        //    remove { _useObject -= value; }
        //}

        //public delegate void UseObject();


        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            //if (!other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        private void Start()
        {
            Action();
        }

        public void Action()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
    }
}
