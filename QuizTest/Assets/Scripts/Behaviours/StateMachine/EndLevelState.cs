namespace Behaviours
{
    internal class EndLevelState : BaseState
    {
        public EndLevelState(GameStateController stateController) : base(stateController)
        {

        }
        public override void EnterState()
        {
            base.EnterState();
            EndPanelEvent.Trigger();
        }
        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
