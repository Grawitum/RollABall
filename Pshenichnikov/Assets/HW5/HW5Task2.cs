using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public static class HW5Task2
    {
        // Start is called before the first frame update
        public static int СountingСharacters (this string self)
        {
            int i = 0;
            foreach (char ch in self)
            {
                i++;
            }
            return i;
        }
    }
}
