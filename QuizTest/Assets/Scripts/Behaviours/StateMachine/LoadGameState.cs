using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class LoadGameState : BaseState
    {
        private LevelLoader _levelLoader;

        public LoadGameState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }
        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }
        private void LoadAll()
        {
            LoadLevelBehaviours();
            StartGameState();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame();
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
