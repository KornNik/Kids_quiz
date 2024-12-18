using UnityEngine;
using Helpers;
using UI;

namespace Behaviours
{
    [System.Serializable]
    class AnswerChecker : IEventSubscription, IEventListener<CellSelectedEvent>
    {
        [SerializeField] private string _rightAnswer;
        private string _userAnswer;

        public string RightAnswer => _rightAnswer;

        public bool CheckAnswer(string selectedAnswer,CellBehaviour cellBeh)
        {
            if (_rightAnswer == selectedAnswer)
            {
                CreateParticleEvent.Trigger(ParticleType.Stars, cellBeh.transform);
                CellsStatusEvent.Trigger(false);
                cellBeh.EffectOnCorrectAnswer(() => AnswerSelectedEvent.Trigger(AnswerType.Correct));
                return true;
            }
            else
            {
                CellsStatusEvent.Trigger(false);
                cellBeh.EffectOnCorrectAnswer(() => AnswerSelectedEvent.Trigger(AnswerType.Wrong));  
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
            CheckAnswer(eventType.Answer, eventType.SelectedCell);
        }

        public void Subscribe()
        {
            this.EventStartListening();
        }

        public void Unsubscribe()
        {
            this.EventStopListening();
        }
    }
}

