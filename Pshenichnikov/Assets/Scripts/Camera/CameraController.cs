using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;
        public GameObject Particle;

        private void Start()
        {
            try
            {
                _offset = transform.position - Player.transform.position;
            }
            catch
            {
                print("игрок не найден");
            }
        }

        private void LateUpdate ()// вынести в класс
        {
            try
            {
                transform.position = Player.transform.position + _offset;
            }
            catch
            {
                print("игрок не найден");
            }
        }

        public void Test()
        {
            Instantiate(Particle, Player.transform);
        }

    }
}
