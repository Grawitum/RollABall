using System.Collections;
using UnityEngine;

namespace RollABall
{
    public class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
