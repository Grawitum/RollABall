using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RollABall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListInteractiveObject _interactiveObject;
        private ListExecuteObject _executeObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        //private InputController _inputController;
        private Reference _reference;
        private MapFactory _mapFactory;
        private InteractiveObjectFactory _interactiveObjectFactory; 
        private int allPoint;
        private ExecutController executController;

        private int _countBonuses;

        private void Awake()
        {
            _interactiveObjectFactory = new InteractiveObjectFactory();
            GameObject bonus = null;
            bonus = _interactiveObjectFactory.GoodBonus;

            GameObject useBonus = null;
            useBonus = _interactiveObjectFactory.UseBonus;

            _interactiveObject = new ListInteractiveObject();
            executController = new ExecutController(_interactiveObject);
            //_executeObject = new ListExecuteObject();

            _reference = new Reference();
            _mapFactory = new MapFactory();

            PlayerBase player = null;
            if(PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _executeObject = new ListExecuteObject(player);

            GameObject map = null;
            map = _mapFactory.Map;

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _executeObject.AddExecuteObject(_cameraController);

            //if (Application.platform == RuntimePlatform.WindowsEditor)
            //{
            //    _inputController = new InputController(player);
            //    _executeObject.AddExecuteObject(_inputController);
            //}

            //executController = new ExecutController(_interactiveObject);

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    allPoint += goodBonus.Point;
                    goodBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);



        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            if(_countBonuses >= allPoint)
            {
                _displayEndGame.GameWin(_countBonuses);
                Time.timeScale = 0.0f;
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;

            executController.Execute(deltaTime);

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

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }
    }

}
