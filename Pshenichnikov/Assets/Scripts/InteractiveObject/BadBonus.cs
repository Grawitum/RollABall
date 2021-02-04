using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        private float _lengthFly;
        private float _speedRotation;
        private PlayerBall playerBall;

        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            FindPlayer();
        }

        protected override void Interaction()
        {
            if (playerBall == null)
            {
                FindPlayer();
            }
            if (!playerBall.Immortality)
            {
                OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            }
            else
            {
                print("Immortality");
            }
        }

        private void FindPlayer()
        {
            playerBall = FindObjectOfType<PlayerBall>();
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
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
