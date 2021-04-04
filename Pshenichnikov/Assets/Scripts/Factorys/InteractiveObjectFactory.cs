using UnityEngine;
using static UnityEngine.Random;

namespace RollABall
{
    public class InteractiveObjectFactory
    {
        private GameObject _goodBonus;
        private GameObject _useBonus;

        public GameObject GoodBonus
        {
            get
            {
                if (_goodBonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("Map/GoodBonus");
                    _goodBonus = Object.Instantiate(gameObject);
                    Transform[] allGoodBonus = _goodBonus.GetComponentsInChildren<Transform>();
                    for (int i = 1; i < allGoodBonus.Length; i++)
                    {
                        if (!allGoodBonus[i].GetComponent<GoodBonus>())
                        {
                            allGoodBonus[i].gameObject.AddComponent<GoodBonus>();
                            allGoodBonus[i].gameObject.GetComponent<GoodBonus>().path = "Map/GoodBonus";
                        }
                    }

                }
                return _goodBonus;
            }
        }

        public GameObject UseBonus
        {
            get
            {
                if (_useBonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("Map/UseBonus");
                    _useBonus = Object.Instantiate(gameObject);
                    Transform[] allUseBonus = _useBonus.GetComponentsInChildren<Transform>();
                    int rBonus;
                    for (int i = 0; i < allUseBonus.Length; i++)
                    {
                        if (allUseBonus[i].name == "Bonus")
                        {
                            rBonus = Range(1, 5);

                            switch (rBonus)
                            {
                                case 1:
                                    allUseBonus[i].gameObject.AddComponent<BadSpeedBonus>();
                                    break;
                                case 2:
                                    allUseBonus[i].gameObject.AddComponent<BadBonus>();
                                    break;
                                case 3:
                                    allUseBonus[i].gameObject.AddComponent<SpeedBonus>();
                                    break;
                                case 4:
                                    allUseBonus[i].gameObject.AddComponent<ImmortalityBonus>();
                                    break;
                            }
                        }
                    }
                }
                return _useBonus;
            }
        }
    }
}
