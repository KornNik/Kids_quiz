using UnityEngine;
using Helpers.Extensions;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelsBundle", menuName = "Data/Level/LevelsBundle")]
    class LevelsBundle : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsDatas;
        [SerializeField, ReadOnly] private int _levelIndex;

        public bool TryGetLevelData(int levelNumber, out LevelData levelData)
        {
            if (levelNumber < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[levelNumber];
                _levelIndex = levelNumber;
                levelData =  neededData;
                return true;
            }
            levelData = null;
            return false;
        }
        public LevelData GetRandomLevelData()
        {
            var random = Random.Range(0, _levelsDatas.Length);
            var level = _levelsDatas[random];
            if (level != null)
            {
                _levelIndex = random;
                return level;
            }
            else
            {
                throw new System.Exception("level is null");
            }
        }
        public bool IsLastLevel()
        {
            if (_levelIndex >= _levelsDatas.Length - 1)
            {
                return true;
            }
            return false;
        }
    }
}
