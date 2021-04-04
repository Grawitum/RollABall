using System.IO;
using UnityEngine;

namespace RollABall
{
    public sealed class SaveBedDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "bedData";
        private readonly string _path;

        public SaveBedDataRepository()
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

        public void Save(BadBonus bed, int number)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveBed = new SavedData
            {
                Position = bed.transform.position,
            };

            _data.Save(saveBed, Path.Combine(_path, _fileName + number + ".bat"));
        }

        public void Load(BadBonus bed, int number)
        {
            var file = Path.Combine(_path, _fileName + number + ".bat");
            if (!File.Exists(file)) return;
            var newBed = _data.Load(file);
            bed.transform.position = newBed.Position;
        }
    }
}
