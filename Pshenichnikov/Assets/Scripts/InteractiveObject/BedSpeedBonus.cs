using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class BedSpeedBonus : InteractiveObject, IFly, IRotation
    {
        private float _speedRotation;
        private float _lengthFly;
        private PlayerBall playerBall;


        private void Awake()
        {
            _speedRotation = Random.Range(10.0f, 50.0f);
            _lengthFly = Random.Range(1.0f, 3.0f);
            playerBall = FindObjectOfType<PlayerBall>();
        }

        protected override void Interaction()
        {
            //base.Interaction();
            playerBall.SpeedDown();

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