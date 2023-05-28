namespace StateMachine
{
    internal class PlayerIdleState : TransformState
    {
        public PlayerIdleState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsIdleHash;
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override bool ConditionEnterState()
        {
            return !InputTransform.IsRunPressed && !InputTransform.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputTransform.IsRunPressed && !InputTransform.IsSpintPressed;
        }
    }
}
