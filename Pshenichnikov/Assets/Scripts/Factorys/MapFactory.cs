    using UnityEngine;

namespace RollABall
{
    public class MapFactory
    {
        public MapFactory()
        {
            Map();
        }

        private void Map()
        {
            var map = Resources.Load<GameObject>("Map/Map");
            Object.Instantiate(map);
        }
    }
}
