using UnityEngine;
using Data;
using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    class Grid
    {
        private Transform _parentTransform;
        private CellCreator _cellCreator;
        private RandomElementSelect _randomElement;
        private List<CellBehaviour> _cells;
        private List<CellBehaviour> _activatedCells;

        private CellBundleData _cellBundleData;

        public Grid(Transform parent)
        {
            _parentTransform = parent;
            _cellBundleData = Services.Instance.DatasBundle.ServicesObject.GetData<CellBundleData>();

            _cells = new List<CellBehaviour>();
            _randomElement = new RandomElementSelect();
            _cellCreator = new CellCreator(_parentTransform, _randomElement);
        }

        public List<CellBehaviour> Cells => _activatedCells;


        public void CreateCells()
        {
            for (int i = 0; i < 9; i++)
            {
                _cells.Add(_cellCreator.CreatCell());
                _cells[i].DeactivateSlot();
            }
        }
        public void FillCells(FieldsSize size)
        {
            foreach (var cell in _cells)
            {
                cell.DeactivateSlot();
            }
            _activatedCells = null;
            _randomElement.GetRandomCellsList();
            var cellsNumber = size.Columns * size.Rows;
            _activatedCells = new List<CellBehaviour>(cellsNumber);
            for(int i = 0;i < cellsNumber; i++)
            {
                _activatedCells.Add(_cells[i]);
                _activatedCells[i].ActivateSlot();
                _activatedCells[i].FillCell(_randomElement.GetRandomCellData());
            }
        } 
    }
}


