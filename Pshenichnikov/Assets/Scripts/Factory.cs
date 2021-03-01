using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RollABall
{

    public class Factory 
    {
        public PlayerType PlayerType = PlayerType.Ball;
        public PlayerBase _player = null;
        private DisplayEndGame _displayEndGame;  
        private DisplayBonuses _displayBonuses;
        private Camera miniMapCamera = null;
        private Canvas miniMapCanvas = null;


        private CameraController _cameraController;
        private Reference _reference;
        private MapFactory _mapFactory;
        private MiniMapFactory _miniMapFactory;
        private InteractiveObjectFactory _interactiveObjectFactory;
        private BonusController bonusController;

        public Factory()
        {
            _interactiveObjectFactory = new InteractiveObjectFactory();
            GameObject bonus = null;
            bonus = _interactiveObjectFactory.GoodBonus;

            GameObject useBonus = null;
            useBonus = _interactiveObjectFactory.UseBonus;

            _reference = new Reference();

            _mapFactory = new MapFactory();
            GameObject map = null;
            map = _mapFactory.Map;

            if (PlayerType == PlayerType.Ball)
            {
                _player = _reference.PlayerBall;
            }


            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            //_executeObject.AddExecuteObject(_cameraController);

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            _miniMapFactory = new MiniMapFactory();

            miniMapCamera = _miniMapFactory.MainMapCamera;
            miniMapCanvas = _miniMapFactory.MiniMapCanvas;


            bonusController = new BonusController(_displayEndGame, _displayBonuses, _reference.RestartButton.gameObject);
        }

        public CameraController cameraController
        {
            get
            {
                return _cameraController;
            }
        }

        public PlayerBase Player
        {
            get
            {
                return _player;
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }



    }
}
