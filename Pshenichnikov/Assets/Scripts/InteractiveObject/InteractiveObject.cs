using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        protected Color _color;
        private bool _isInteractable;
        Dictionary<object, bool> _cache = new Dictionary<object, bool>();

        protected bool IsInteractable
        {
            get { return _cache[0]; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
                _cache[0] = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        protected private void Fly(float lengthFly)
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, lengthFly),
                transform.localPosition.z);
        }

        protected private void Rotation(float speedRotation)
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
        }

        protected private void Flicker(Material material)
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        private protected  PlayerBall FindPlayer()
        {
            return FindObjectOfType<PlayerBall>();
        }

    }
}
