using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public abstract class UseBonus : InteractiveObject
    {
        private PlayerBall _playerBall;


        private void Awake()
        {
            _playerBall = FindObjectOfType<PlayerBall>();
        }


    }
}
