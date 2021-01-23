using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{

    public sealed class PlayerBall : Player
    {
        private bool speedUpOn = false;
        private float speedBonusTime;
        private float speedBedBonusTime;
        private bool speedDownOn;

        public PlayerBall(float speed) : base(speed)
        {
            //Speed = 3f;
            //speed = 3f;
        }

        private void FixedUpdate()
        {
            Move();
            if (speedUpOn)
            {
                speedBonusTime -= 0.1f;
                print(speedBonusTime);
                if(speedBonusTime <= 0f)
                {
                    SpeedNormal();
                    speedUpOn = false;
                    print("buf on");
                }
            }

            if (speedDownOn)
            {
                speedBedBonusTime -= 0.1f;
                print(speedBedBonusTime);
                if (speedBedBonusTime <= 0f)
                {
                    SpeedNormal();
                    speedDownOn = false;
                    print("buf on");
                }
            }
        }

        public void SpeedUP()
        {

            Speed *= 2.0f;
            speedBonusTime = 10.0f;
            speedUpOn = true;

        }

        public void SpeedDown()
        {

            Speed /= 2.0f;
            speedBedBonusTime = 7.0f;
            speedDownOn = true;

        }

        private void SpeedNormal()
        {
            Speed = 3.0f;
        }
    }
    
}
