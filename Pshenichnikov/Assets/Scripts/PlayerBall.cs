using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{

    public sealed class PlayerBall : Player
    {
        public PlayerBall(float speed) : base(speed)
        {
            //Speed = 3f;
            //speed = 3f;
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
    
}
