using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CellBundleData", menuName = "Data/Cell/CellBundle")]
    class CellBundleData : ScriptableObject
    {
        [SerializeField] private CellListData[] _listCellsBundleData = new CellListData[2];

        public CellListData[] ListCellsBundleData => _listCellsBundleData;

        public CellListData GetRandomList()
        {
            var random = Random.Range(0, _listCellsBundleData.Length);
            var listCells =  ListCellsBundleData[random];
            return listCells;
        }
    }
}

