using System.Collections.Generic;
using Data;
using Helpers;

namespace Behaviours
{
    class RandomElementSelect
    {
        private List<string> _spriteName = new List<string>();
        private CellBundleData _cellBundleData;
        private CellListData _currentCellListData;

        public RandomElementSelect()
        {
            _cellBundleData = Services.Instance.DatasBundle.ServicesObject.GetData<CellBundleData>();
        }

        public CellListData GetRandomCellsList()
        {
            var randomList = _cellBundleData.GetRandomList();
            _currentCellListData = randomList;
            return randomList;
        }
        public CellStruct GetRandomCellData()
        { 
            var cell = _currentCellListData.GetRandomCellData();
            return cell;
        }
    }
}

