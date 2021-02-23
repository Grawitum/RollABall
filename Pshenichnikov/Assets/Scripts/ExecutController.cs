using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class ExecutController : IExecute
    {
        private ListInteractiveObject _interactiveObject;

        public ExecutController(ListInteractiveObject interactiveObject)
        {
            _interactiveObject = interactiveObject;
        }

        public void Execute(float deltaTime)
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var executeObject = _interactiveObject[i];

                if (executeObject == null)
                {
                    continue;
                }
                if (executeObject is IFly flyObject)
                {
                    flyObject.Fly();
                }
                if (executeObject is IRotation rotationObject)
                {
                    rotationObject.Rotation();
                }
                if (executeObject is IFlicker flicerObject)
                {
                    flicerObject.Flicker();
                }
            }
        }
    }
}
