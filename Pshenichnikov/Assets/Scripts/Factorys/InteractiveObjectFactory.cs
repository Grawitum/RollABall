using UnityEngine;
using static UnityEngine.Random;

namespace RollABall
{
    public class InteractiveObjectFactory
    {
        public InteractiveObjectFactory()
        {
            GoodBonus();
            UseBonus();
        }

        private void GoodBonus()
        {            
            var goodBonus = Resources.Load<GameObject>("Map/GoodBonus");
            Transform[] allGoodBonus = goodBonus.GetComponentsInChildren<Transform>();
            for (int i = 1; i < allGoodBonus.Length; i++)
            {
                if (!allGoodBonus[i].GetComponent<GoodBonus>())
                {
                    allGoodBonus[i].gameObject.AddComponent<GoodBonus>();
                    allGoodBonus[i].gameObject.GetComponent<GoodBonus>().path = "Map/GoodBonus";
                }
            }
            Object.Instantiate(goodBonus);
        }

        private void UseBonus()
        {
            var useBonus = Resources.Load<GameObject>("Map/UseBonus");
            Transform[] allUseBonus = useBonus.GetComponentsInChildren<Transform>();
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
            Object.Instantiate(useBonus);
        }
    }
}
