using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class BadSpeedBonus : InteractiveObject, IFly, IRotation
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
                FindPlayer();
            }
            playerBall.Speed -= 1.0f;
        }

        private void FindPlayer()
        {
            playerBall = FindObjectOfType<PlayerBall>();
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

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotation();
        }
    }
}