using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class SpeedBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            base.Interaction();
            print("speed up");
        }
    }
}
