﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class EndGame : InteractiveObject
    {
        protected override void Interaction()
        {
            base.Interaction();
            print("end game");
        }
    }
}