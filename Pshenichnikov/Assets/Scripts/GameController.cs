using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RollABall
{
    public sealed class GameController : MonoBehaviour
    {

        private Factory _factory;

        private ExecutController executController;


        private void Awake()
        {

            _factory = new Factory();

            executController = new ExecutController(_factory.Player, _factory.cameraController);
        }



        private void Update()
        {
            var deltaTime = Time.deltaTime;

            executController.Execute(deltaTime);
        }

    }

}
