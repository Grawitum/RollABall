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
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private MapFactory _mapFactory;
        private InteractiveObjectFactory _interactiveObjectFactory; 
        private int allPoint;

        private int _countBonuses;

        //private InteractiveObject[] _interactiveObjects;
        //public GameObject Particle;

        //public Text _finishGameLabel;
        //private DisplayEndGame _displayEndGame;
        //private CameraController _cameraController;

        //public Player player;

        private void Awake()
        {
            _interactiveObjectFactory = new InteractiveObjectFactory();
            GameObject bonus = null;
            bonus = _interactiveObjectFactory.GoodBonus;

            GameObject useBonus = null;
            useBonus = _interactiveObjectFactory.UseBonus;

            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();
            _mapFactory = new MapFactory();
            //_interactiveObjectFactory = new InteractiveObjectFactory();

            //_reference.Map;  фактори с авэйком, туда карту и бонусы

            PlayerBase player = null;
            if(PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            GameObject map = null;
            map = _mapFactory.Map;

            //GameObject bonus = null;
            //bonus = _interactiveObjectFactory.GoodBonus;

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
            }

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
                    //print(allPoint);
                    goodBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);



        }

        //public void Test()
        //{ 
        //    Instantiate(Particle,new Vector3(player.transform.position.x,player.transform.position.y), Quaternion.identity);
        //}

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
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
                //interactiveObject.Execute(deltaTime);
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
