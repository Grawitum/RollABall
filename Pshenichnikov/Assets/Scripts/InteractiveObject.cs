using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{


    public class InteractiveObject  : MonoBehaviour
    {
        protected virtual void Interaction()
        {
            //print("11");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                Interaction();
            }
        }
    }
}
