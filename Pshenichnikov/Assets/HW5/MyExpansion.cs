using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RollABall
{
    public static class MyExpansion 
    {

        public static T AddTo<T>(this T self, ICollection<T> coll)  //добавление объекта в список
        {
            coll.Add(self);
            return self;
        }

        public static bool TryBool(this string self) // Проверка на какое булевское значение находится в строке
        {
            return Boolean.TryParse(self, out var res) && res;
        }

        public static bool IsOneOf<T>(this T self, params T[] elem)  //указывающее, встречается ли указанный символ внутри этой строки, используя указанные правила сравнения.
        {
            return elem.Contains(self);
        }

        public static T GetOrAddComponent<T>(this Component child) where T : Component  // проверяет есть ли на объекте компонент если нету то добавляет и возвращает если есть то возвращает
        {
            T result = child.GetComponent<T>() ?? child.gameObject.AddComponent<T>();
            return result;
        }

        public static T[] Concat<T>(this T[] x, T[] y)   //Позволяет склеивать 2 массива
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            var oldLen = x.Length;
            Array.Resize(ref x, x.Length + y.Length);
            Array.Copy(y, 0, x, oldLen, y.Length);
            return x;
        }

        public static T DeepCopy<T>(this T self)  // Выполняет глубокое копирование ссылочного объекта
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }
            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
