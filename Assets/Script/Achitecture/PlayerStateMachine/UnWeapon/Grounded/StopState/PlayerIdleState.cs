namespace StateMachine
{
    internal class PlayerIdleState : TransformState
    {
        public PlayerIdleState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsIdleHash;
        }

        public override void SwitchToOtherRoot()
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            SwitchToOtherRoot();
        }

    }
}
