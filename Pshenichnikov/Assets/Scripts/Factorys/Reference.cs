﻿using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restartButton;

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    if (!Resources.Load<GameObject>("Player").GetComponent<PlayerBall>())
                    {
                        Resources.Load<GameObject>("Player").AddComponent<PlayerBall>();
                    }
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }
                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Canvas");
                    Object.Instantiate(gameObject);
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }

    }
}
