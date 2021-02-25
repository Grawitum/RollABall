using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class ExecutController : IExecute
    {
        private ListInteractiveObject _interactiveObject;
        private ListExecuteObject _executeObject;

        public ExecutController(PlayerBase player, CameraController cameraController)
        {
            _interactiveObject = new ListInteractiveObject();
            _executeObject = new ListExecuteObject(player, cameraController);
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
            for (var i = 0; i < _executeObject.Length; i++)
            {
                var executeObject = _executeObject[i];

                if (executeObject == null)
                {
                    continue;
                }
                executeObject.Execute(deltaTime);
            }
        }
    }
}
