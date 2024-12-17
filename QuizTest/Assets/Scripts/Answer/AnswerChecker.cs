using UnityEngine;
using Helpers;

namespace Behaviours
{
    [System.Serializable]
    class AnswerChecker : IEventSubscription, IEventListener<CellSelectedEvent>
    {
        [SerializeField] private string _rightAnswer;
        private string _userAnswer;

        public string RightAnswer => _rightAnswer;

        public void Subscribe()
        {
            this.EventStartListening();
        }

        public void Unsubscribe()
        {
            this.EventStopListening();
        }

        public bool CheckAnswer(string selectedAnswer,Vector2 cellPosition)
        {
            if (_rightAnswer == selectedAnswer)
            {
                AnswerSelectedEvent.Trigger(AnswerType.Correct, cellPosition);
                return true;
            }
            else
            {
                AnswerSelectedEvent.Trigger(AnswerType.Wrong);
                return false;
            }
        }

        public void SetRightAnswer(string rightAnswer)
        {
            _rightAnswer = rightAnswer;
        }

        private void ResetAnswer()
        {
            _rightAnswer = null;
        }
        public void OnEventTrigger(CellSelectedEvent eventType)
        {
            CheckAnswer(eventType.Answer, eventType.CellPosition);
        }
    }
}

