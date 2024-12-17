using Helpers;
using UnityEngine;

namespace Behaviours
{
    enum AnswerType
    {
        None,
        Correct,
        Wrong,
    }
    struct AnswerSelectedEvent
    {
        private static AnswerSelectedEvent _answerEvent;

        private AnswerType _type;
        private Vector2 _cellPosition;

        public AnswerType Type => _type;
        public Vector2 CellPosition => _cellPosition;

        public static void Trigger(AnswerType answerType, Vector2 cellPosition = default)
        {
            _answerEvent._type = answerType;
            _answerEvent._cellPosition = cellPosition;
            EventManager.TriggerEvent(_answerEvent);
        }
    }
}
