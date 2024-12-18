using UnityEngine;
using Data;
using Helpers;
using Behaviours;

namespace Controllers
{
    class LevelLoader
    {
        private GameObject _level;
        private LevelData _levelData;
        private LevelsBundle _levelsBundle;

        private int _levelIndex = 0;

        public LevelLoader()
        {
            _levelsBundle = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>();
        }

        public void LoadLevelGame(int index)
        {
            LoadLevelVisuals(index);
        }
        public void LoadLevelGame()
        {
            LoadLevelVisuals(_levelIndex);
        }
        public void LoadNextLevel()
        {
            var nextLevelIndex = _levelIndex + 1;
            LoadLevelVisuals(nextLevelIndex);
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
            }
        }
        public void ResetLevel()
        {
            _levelIndex = 0;
        }
        public bool IsLastLevel()
        {
            if (_levelsBundle.IsLastLevel()) { return true; }
            return false;
        }

        private bool LoadLevelVisuals(int index)
        {
            ClearLevelFull();
            if (_levelsBundle.TryGetLevelData(index, out _levelData))
            {
                _level = GameObject.Instantiate(_levelData.LevelPrefab, _levelData.LevelPosition, Quaternion.identity);
                _level.transform.localPosition = Vector3.zero;
                _level.transform.localRotation = Quaternion.identity;

                var levelBehaviour = _level.GetComponent<Level>();
                levelBehaviour.SetDifficulty(_levelData.LevelDifficulty);
                _levelIndex = index;
                Services.Instance.Level.SetObject(levelBehaviour);
                return true;
            }
            return false;
        }
    }
}
