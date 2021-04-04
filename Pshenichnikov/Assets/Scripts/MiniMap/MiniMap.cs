using UnityEngine;

namespace RollABall
{
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _player;
        private Vector3 _newPosition;
        private void Start()
        {
            _player = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0, 15.0f, 0);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            GetComponent<Camera>().targetTexture = rt;
        }

        private void LateUpdate()
        {
            _newPosition = _player.position;
            _newPosition.y = transform.position.y;
            transform.position = _newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }

}
