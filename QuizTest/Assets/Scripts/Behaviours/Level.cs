using UnityEngine;
using Data;
using Helpers.Extensions;

namespace Behaviours
{
    sealed class Level : MonoBehaviour
    {
        [SerializeField, ReadOnly] private DifficultyFieldsSize _levelDifficulty;

        public DifficultyFieldsSize LevelDifficulty => _levelDifficulty;

        public void SetDifficulty(DifficultyFieldsSize levelDifficulty)
        {
            _levelDifficulty = levelDifficulty;
        }
    }
}
