using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private EndLevel _endLevel;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _endLevel = new EndLevel();
        }

        public override void EnterState()
        {
            _endLevel.Subscribe();
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            Services.Instance.GridBehaviour.ServicesObject.CreateGrid();
        }

        public override void ExitState()
        {
            _endLevel.Unsubscribe();
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }
    }
}
