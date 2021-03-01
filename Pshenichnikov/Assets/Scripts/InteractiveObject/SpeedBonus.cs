using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class SpeedBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _lengthFly;
        private PlayerBall playerBall;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 3.0f);
            FindPlayer();
        }

        protected override void Interaction()
        {
            if (playerBall == null)
            {
                FindPlayer();
            }
            playerBall.Speed += 1;
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

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
