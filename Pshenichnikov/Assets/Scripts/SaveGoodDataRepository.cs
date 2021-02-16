using System.IO;
using UnityEngine;

namespace RollABall
{
    public sealed class SaveGoodDataRepository 
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "goodData";
        private readonly string _path;

        public SaveGoodDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(GoodBonus good,int number)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveGood = new SavedData
            {
                Position = good.transform.position,
            };

            _data.Save(saveGood, Path.Combine(_path, _fileName + number + ".bat"));
        }

        public void Load(GoodBonus good, int number)
        {
            var file = Path.Combine(_path, _fileName + number + ".bat");
            if (!File.Exists(file)) return;
            var newGood = _data.Load(file);
            good.transform.position = newGood.Position;
        }
    }
}
