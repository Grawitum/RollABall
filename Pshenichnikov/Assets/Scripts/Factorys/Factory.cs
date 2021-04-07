using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollABall
{
    public class Factory 
    {
        private PlayerType _playerType = PlayerType.Ball;
        private PlayerBase _player = null;
        private DisplayEndGame _displayEndGame;  
        private DisplayBonuses _displayBonuses;

        private CameraController _cameraController;
        private Reference _reference;

        public Factory()
        {
            _reference = new Reference();

            if (_playerType == PlayerType.Ball)
            {
                _player = _reference.PlayerBall;
            }

            new MapFactory();
            new InteractiveObjectFactory();
            new MiniMapFactory();


            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            new BonusController(_displayEndGame, _displayBonuses, _reference.RestartButton.gameObject);
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
