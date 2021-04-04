using UnityEngine;

namespace RollABall
{


    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 3.0f;
        public bool Immortality = false;
        public abstract void Move(float x, float y, float z);
    }
}
