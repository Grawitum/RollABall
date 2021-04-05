using UnityEngine;

namespace RollABall
{
    public class MiniMapFactory
    {
        public MiniMapFactory()
        {
            MainMapCamera();
            MiniMapCanvas();
        }

        private void  MainMapCamera ()
        {         
            var miniMapCamera = Resources.Load<Camera>("MiniMap/MiniMapCamera");
            Object.Instantiate(miniMapCamera);                               
        }

        private void MiniMapCanvas()
        {
            var minimapCanvas = Resources.Load<Canvas>("MiniMap/MiniMapCanvas");
            Object.Instantiate(minimapCanvas);
        }
    }
}
