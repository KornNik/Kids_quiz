using Helpers;
using UI;
using UnityEngine;

namespace Behaviours
{
    struct CellSelectedEvent
    {
        private static CellSelectedEvent _cellSelectedEvent;

        private string _answer;
        private CellBehaviour _selectedCell;

        public string Answer => _answer;
        public CellBehaviour SelectedCell => _selectedCell;

        public static void Trigger(string answer, CellBehaviour selectedCell)
        {
            _cellSelectedEvent._answer = answer;
            _cellSelectedEvent._selectedCell = selectedCell;
            EventManager.TriggerEvent(_cellSelectedEvent);
        }
    }
}
