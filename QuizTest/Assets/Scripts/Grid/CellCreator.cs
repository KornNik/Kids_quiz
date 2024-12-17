using Helpers;
using UnityEngine;
using System.Collections.Generic;

namespace Behaviours
{
    class CellCreator
    {
        private float _cellSize;
        private Transform _parent;

        private CellBehaviour _cellPrefab;
        private RandomElementSelect _randomElementSelect;

        private List<CellBehaviour> _cells;
        private BasePool<CellBehaviour> _cellsPool;

        public CellCreator(Transform parent,RandomElementSelect _randomElementSelect)
        {
            _parent = parent;

            _cellPrefab = Services.Instance.DataResourcePrefabs.ServicesObject.GetCellPrefab();
            _cellSize = _cellPrefab.GetComponent<RectTransform>().rect.height;

            _cells = new List<CellBehaviour>(9);
            _cellsPool = new BasePool<CellBehaviour>(() => PreLoad(_cellPrefab), GetAction, ReturnAction, 9);
        }

        public CellBehaviour CreatCell()
        {
            var cell = _cellsPool.Get();
            _cells.Add(cell);
            return cell;
        }

        #region Pool

        public CellBehaviour PreLoad(CellBehaviour prefab)
        {
            var slot = GameObject.Instantiate(_cellPrefab);
            slot.transform.parent = _parent;
            return slot;
        }
        public void GetAction(CellBehaviour itemSlot) => itemSlot.ActivateSlot();
        public void ReturnAction(CellBehaviour itemSlot) => itemSlot.DeactivateSlot();

        #endregion

    }
}

