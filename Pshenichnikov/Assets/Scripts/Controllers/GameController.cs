using UnityEngine;

namespace RollABall
{
    public sealed class GameController : MonoBehaviour
    {

        private Factory _factory;
        private ExecutController _executController;
        private float _deltaTime;


        private void Awake()
        {
            _factory = new Factory();
            _executController = new ExecutController(_factory.Player, _factory.cameraController);
        }



        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _executController.Execute(_deltaTime);
        }

    }

}
