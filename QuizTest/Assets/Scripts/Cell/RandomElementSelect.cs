using System.Collections.Generic;
using Data;
using Helpers;
using Helpers.Extensions;

namespace Behaviours
{
    class RandomElementSelect
    {
        private List<CellStruct> _cellStructsFromList;
        private CellBundleData _cellBundleData;
        private CellListData _currentCellListData;

        public RandomElementSelect()
        {
            _cellBundleData = Services.Instance.DatasBundle.ServicesObject.GetData<CellBundleData>();
            _cellStructsFromList = new List<CellStruct>(10);
        }

        public CellListData GetRandomCellsList()
        {
            var randomList = _cellBundleData.GetRandomList();
            _currentCellListData = randomList;
            _cellStructsFromList.Clear();  // Clear list to avoid duplicates in next call.
            _cellStructsFromList.AddRange(_currentCellListData.CellsStruct);
            return randomList;
        }
        public CellStruct GetRandomCellData()
        {
            var cell = ListExtension.ReturnAndDeleteRandomListElement(_cellStructsFromList);
            return cell;
        }
    }
}

