using UnityEngine;

namespace RollABall
{
    public class BonusController 
    {
        private int _allPoint;
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
            for (int i = 0; i < _bonuses.Length; i++)
            {
                if (_bonuses[i] is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (_bonuses[i] is GoodBonus goodBonus)
                {
                    _allPoint += goodBonus.Point();
                    goodBonus.OnPointChange += AddBonuse;
                }
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            _restartBotton.SetActive(true);
            Time.timeScale = 0.0f;
        }

        public void Dispose()
        {
            for (int i = 0; i < _bonuses.Length; i++)
            {
                if (_bonuses[i] is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (_bonuses[i] is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            if (_countBonuses >= _allPoint)
            {
                _displayEndGame.GameWin(_countBonuses);
                Time.timeScale = 0.0f;
            }
        }
    }
}
