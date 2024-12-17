using UnityEngine;

namespace Data
{
    [System.Serializable]
    struct CellStruct
    {
        public Sprite Image;
        public string Name;
    }
    [CreateAssetMenu(fileName = "CellList", menuName = "Data/Cell/CellList")]
    class CellListData : ScriptableObject
    {
        [SerializeField] private CellStruct[] _cellsStruct = new CellStruct[10];

        public CellStruct[] CellsStruct => _cellsStruct;

        public CellStruct GetRandomCellData()
        {
            var random = Random.Range(0, CellsStruct.Length);
            var cellData = _cellsStruct[random];
            return cellData;
        }
    }
}

