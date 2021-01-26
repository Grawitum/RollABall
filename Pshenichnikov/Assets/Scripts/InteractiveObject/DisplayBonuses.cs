using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{
    public sealed class DisplayBonuses
    {
        private Text _text;
        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            try
            {
                _text.text = $"Вы набрали {value} очков";
            }
            catch
            {
                Debug.Log("Тестовое поле не найдено");
            }
        }
    }
}
