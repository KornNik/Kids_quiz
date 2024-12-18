using Helpers;

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

        public AnswerType Type => _type;

        public static void Trigger(AnswerType answerType)
        {
            _answerEvent._type = answerType;
            EventManager.TriggerEvent(_answerEvent);
        }
    }
}
