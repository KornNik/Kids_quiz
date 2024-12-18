using Controllers;
using Helpers;
using UI;
using UnityEngine;

namespace Behaviours
{
    sealed class GameState : BaseState, IEventListener<AnswerSelectedEvent>
    {
        private LevelLoader _levelLoader;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            this.EventStartListening();
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            Services.Instance.GridBehaviour.ServicesObject.CreateGrid();
        }

        public override void ExitState()
        {
            this.EventStopListening();
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }

        public void OnEventTrigger(AnswerSelectedEvent eventType)
        {
            Debug.Log(eventType.Type);
            if(eventType.Type == AnswerType.Correct)
            {
                if (!_levelLoader.IsLastLevel())
                {
                    _levelLoader.LoadNextLevel();
                    Services.Instance.GridBehaviour.ServicesObject.CreateGrid();
                }
                else
                {
                    ChangeGameStateEvent.Trigger(GameStateType.EndLevelState);
                }
            }
            if (eventType.Type == AnswerType.Wrong)
            {
                Services.Instance.GridBehaviour.ServicesObject.CreateGrid();
            }
        }
    }
}
