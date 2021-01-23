using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class SavedData<T> where T : struct
    {
        public int CountBonuses;
        public T IdPlayer = default;
    }
}
