using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers.Extensions
{
    sealed class ListExtension
    {
        public static T ReturnAndDeleteRandomListElement<T>(List<T> list)
        {
            var randomElement = Random.Range(0, list.Count);
            var element = list[randomElement];
            if (element == null)
            {
                Debug.LogError("Cell name is empty in CellListData");
            }
            list.Remove(element);
            return element;
        }
    }
}
