namespace RollABall
{
    public class ExecutController : IExecute
    {
        private ListInteractiveObject _interactiveObjects;
        private ListExecuteObject _executeObjects;
        private InteractiveObject _interactiveObject;
        private IExecute _executeObject;

        public ExecutController(PlayerBase player, CameraController cameraController)
        {
            _interactiveObjects = new ListInteractiveObject();
            _executeObjects = new ListExecuteObject(player, cameraController);
        }

        public void Execute(float deltaTime)
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                _interactiveObject = _interactiveObjects[i];

                if (_interactiveObject == null)
                {
                    continue;
                }
                if (_interactiveObject is IMove moveObject)
                {
                    moveObject.Move();
                }
            }
            for (var i = 0; i < _executeObjects.Length; i++)
            {
                _executeObject = _executeObjects[i];

                if (_executeObject == null)
                {
                    continue;
                }
                _executeObject.Execute(deltaTime);
            }
        }
    }
}
