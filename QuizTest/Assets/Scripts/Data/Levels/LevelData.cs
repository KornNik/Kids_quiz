using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private Vector3 _levelPosition;
        [SerializeField] private DifficultyFieldsSize _levelDifficulty;

        public DifficultyFieldsSize LevelDifficulty => _levelDifficulty;
        public GameObject LevelPrefab => _levelPrefab;
        public Vector3 LevelPosition => _levelPosition;
        public string Name => _name;
    }
}
