using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class GoodBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            base.Interaction();
            print("Check");
        }
    }
}
