using UnityEngine;

namespace Data
{
    struct FieldsSize
    {
        public int Rows;
        public int Columns;

        public FieldsSize(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
    [CreateAssetMenu(fileName ="LevelFieldsSize",menuName ="Data/Level/LevelFieldsSize")]
    sealed class DifficultyFieldsSize : ScriptableObject
    {
        [SerializeField] private LevelType _levelDiffucultyType;
        [SerializeField] private int _rowsSize;
        [SerializeField] private int _columnsSize;

        public FieldsSize GetLevelFieldsSize()
        {
            return new FieldsSize(_rowsSize, _columnsSize);
        }
    }
}
