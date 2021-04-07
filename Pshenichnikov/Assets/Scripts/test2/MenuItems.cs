using UnityEditor;
using UnityEngine;

namespace RollABall
{
    public class MenuItems 
    {
        [MenuItem("RollABall/MyPynkt ")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "RollABall");
        }
    }
}
