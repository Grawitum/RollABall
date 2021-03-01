using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class MapFactory
    {
        private GameObject _map;

        public GameObject Map
        {
            get
            {
                if (_map == null)
                {
                    var gameObject = Resources.Load<GameObject>("Map/Map");
                    _map = Object.Instantiate(gameObject);
                }
                return _map;
            }
        }
    }
}
