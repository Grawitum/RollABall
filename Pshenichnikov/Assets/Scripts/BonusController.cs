using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollABall
{
    public class BonusController 
    {

        private int allPoint;
        private int _countBonuses;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private GameObject _restartBotton;

        private ListInteractableObject _bonuses;
        public BonusController(DisplayEndGame displayEndGame, DisplayBonuses displayBonuses,GameObject restartBotton)
        {
            _bonuses = new ListInteractableObject();
            _displayEndGame = displayEndGame;
            _displayBonuses = displayBonuses;
            _restartBotton = restartBotton;
            Subscription();
        }

        private void Subscription()
        {
            foreach (var o in _bonuses)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    allPoint += goodBonus.Point;
                    goodBonus.OnPointChange += AddBonuse;
                }
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            _restartBotton.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        public void Dispose()
        {
            foreach (var o in _bonuses)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            if (_countBonuses >= allPoint)
            {
                _displayEndGame.GameWin(_countBonuses);
                Time.timeScale = 0.0f;
            }
        }
    }
}
