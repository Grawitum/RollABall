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
                    //if(gameObject == null)
                    //{
                    //    Debug.Log("Null");
                    //}
                    _goodBonus = Object.Instantiate(gameObject);
                    //_goodBonus.GetComponent<GoodBonus>().path = "Map/GoodBonus";
                    Transform[] allGoodBonus = _goodBonus.GetComponentsInChildren<Transform>();
                    //foreach (Transform i in allGoodBonus)
                    //{
                    //    Debug.Log(i.name);
                    //}
                    for (int i = 1; i < allGoodBonus.Length; i++)
                    {
                        //Debug.Log(allGoodBonus[i].gameObject.name);
                        if (!allGoodBonus[i].GetComponent<GoodBonus>())
                        {
                            //Debug.Log("add");
                            allGoodBonus[i].gameObject.AddComponent<GoodBonus>();
                            allGoodBonus[i].gameObject.GetComponent<GoodBonus>().path = "Map/GoodBonus";
                        }
                    }

                }
                //Debug.Log("input");
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
                    //if(gameObject == null)
                    //{
                    //    Debug.Log("Null");
                    //}
                    _useBonus = Object.Instantiate(gameObject);
                    Transform[] allUseBonus = _useBonus.GetComponentsInChildren<Transform>();
                    int rBonus;
                    foreach (Transform i in allUseBonus)
                    {

                        if(i.name == "Bonus")
                        {
                            rBonus = Range(1, 5);
                            //Debug.Log(rBonus);
                            switch (rBonus)
                            {
                                case 1:
                                    i.gameObject.AddComponent<BadSpeedBonus>();
                                    break;
                                case 2:
                                    i.gameObject.AddComponent<BadBonus>();
                                    break;
                                case 3:
                                    i.gameObject.AddComponent<SpeedBonus>();
                                    break;
                                case 4:
                                    i.gameObject.AddComponent<ImmortalityBonus>();
                                    break;
                            }
                        }
                    }
                    //for (int i = 1; i < allUseBonus.Length; i++)
                    //{
                    //    //Debug.Log(allGoodBonus[i].gameObject.name);
                    //    if (!allUseBonus[i].GetComponent<Skript>())
                    //    {
                    //        //Debug.Log("add");
                    //        allUseBonus[i].gameObject.AddComponent<T>();
                    //    }
                    //}

                }
                //Debug.Log("input");
                return _useBonus;
            }
        }
    }
}
