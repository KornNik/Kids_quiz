using Helpers;

namespace Behaviours
{
    struct RandomAnswerEvent
    {
        private static RandomAnswerEvent _randomAnswerEvent;

        private string _answer;

        public string Answer => _answer;

        public static void Trigger(string answer)
        {
            _randomAnswerEvent._answer = answer;
            EventManager.TriggerEvent(_randomAnswerEvent);
        }
    }
}
