using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace RollABall
{
    public class HW5Main : MonoBehaviour
    {
        void Start()
        {
            //Task2();
            //Task3();
            Task4();
        }

        private void Task2()
        {
            string text = "123456789";
            int ch = text.СountingСharacters();
            Debug.Log("HW5 task 2:  " + ch);
        }

        private void Task3()
        {
            List<double> a = new List<double> { 1, 2, 4, 3, 5 , 4, 4, 2, 6, 2.2, 5.1, 6.6, 1.1, 1 };
            a.Add(5);
            a.Sort();
            var onlyInt = from n in a where n % 1 == 0 select n;
            //Debug.Log( a.BinarySearch(1));
            foreach(int i in onlyInt.Distinct())
            {
                Debug.Log(i + " - " + onlyInt.Where(x => x == i).Count() + " Раз");
            }
        }

        private void Task4()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            //foreach (var pair in dict)
            //{
            //    Debug.Log($"{pair.Key} - {pair.Value} ");
            //}
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            var d2 = from n in dict
                     orderby n.Value ascending
                     select n;
            var d3 = dict.OrderBy(u => u.Value);

            
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            foreach (var pair in d2)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            foreach (var pair in d3)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

        }


    }
}
