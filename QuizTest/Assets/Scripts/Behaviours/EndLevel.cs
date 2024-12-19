using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class EndLevel : IEventListener<AnswerSelectedEvent>, IEventSubscription
    {
        private LevelLoader _levelLoader;
        private IGrid _grid;

        public EndLevel()
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _grid = Services.Instance.GridBehaviour.ServicesObject;
        }

        public void CheckLevelStatus(AnswerType answerType)
        {
            UnityEngine.Debug.Log("End Level");
            if (answerType == AnswerType.Correct)
            {
                if (!_levelLoader.IsLastLevel())
                {
                    _levelLoader.LoadNextLevel();
                    _grid.CreateGrid();
                }
                else
                {
                    ChangeGameStateEvent.Trigger(GameStateType.EndLevelState);
                }
            }
            if (answerType == AnswerType.Wrong)
            {
                _grid.CreateGrid();
            }
        }

        public void Subscribe()
        {
            this.EventStartListening();
        }
        public void Unsubscribe()
        {
            this.EventStopListening();
        }
        public void OnEventTrigger(AnswerSelectedEvent eventType)
        {
            CheckLevelStatus(eventType.Type);
        }
    }
}
