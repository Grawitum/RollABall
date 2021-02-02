using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace RollABall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private InteractiveObject[] _interactiveObjects;
        public GameObject Particle;

        public Text _finishGameLabel;
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;

        public Player player;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            foreach (var o in _interactiveObjects)
            {
                if (o is GoodBonus goodBonus)
                {
                    goodBonus._useObject +=Test;
                }
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    badBonus.CaughtPlayer += (sender, args) =>
                    {
                        Debug.Log($"Вы проиграли. Вас убил {(o).name} {args.Color} цвета");
                    };
                }
            }

        }

        public void Test()
        { 
            Instantiate(Particle,new Vector3(player.transform.position.x,player.transform.position.y), Quaternion.identity);
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }

}
