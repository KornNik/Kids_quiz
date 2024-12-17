using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class ExitGameState : BaseState
    {
        private LevelLoader _levelLoader;
        public ExitGameState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }
        public override void EnterState()
        {
            DeletLevel();
            StartMenuState();
        }

        private void DeletLevel()
        {
            _levelLoader.ClearLevelFull();
        }
        private void StartMenuState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.ManuState);
        }
    }
}
