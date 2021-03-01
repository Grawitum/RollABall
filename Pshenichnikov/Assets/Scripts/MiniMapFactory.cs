using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class MiniMapFactory 
    {
        private Canvas _miniMapConvas;
        private Camera _miniMapCamera;
        public Camera MainMapCamera
        {

            get
            {
                if (_miniMapCamera == null)
                {
                    var gameObject = Resources.Load<Camera>("MiniMap/MiniMapCamera");
                    _miniMapCamera = Object.Instantiate(gameObject);
                    
                }
                return _miniMapCamera;
            }
        }

        public Canvas MiniMapCanvas
        {
            get
            {
                if (_miniMapConvas == null)
                {
                    var gameObject = Resources.Load<Canvas>("MiniMap/MiniMapCanvas");
                    //gameObject.GetComponent<Canvas>().worldCamera = _miniMapCamera;
                    _miniMapConvas = Object.Instantiate(gameObject);
                }
                return _miniMapConvas;
            }
        }
    }
}
