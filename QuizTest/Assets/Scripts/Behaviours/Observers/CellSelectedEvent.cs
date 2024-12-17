using Helpers;
using UnityEngine;

namespace Behaviours
{
    struct CellSelectedEvent
    {
        private static CellSelectedEvent _cellSelectedEvent;

        private string _answer;
        private Vector2 _cellPosition;

        public string Answer => _answer;
        public Vector2 CellPosition => _cellPosition;

        public static void Trigger(string answer, Vector2 cellPosition)
        {
            _cellSelectedEvent._answer = answer;
            _cellSelectedEvent._cellPosition = cellPosition;
            EventManager.TriggerEvent(_cellSelectedEvent);
        }
    }
}
