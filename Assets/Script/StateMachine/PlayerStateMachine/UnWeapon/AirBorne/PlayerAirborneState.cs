
namespace StateMachine
{
    internal class PlayerAirborneState : TransformState
    {
        public PlayerAirborneState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsAirborneHash;
        }

        //public override void SwitchToFriendState()
        //{
        //    if(StateContain.Grounded.ConditionEnterState()) SwitchState(StateContain.Grounded);
        //}

        public override void EnterState()
        {
            base.EnterState();
        }

        //public void InitilationChildrenState()
        //{
        //    if(StateContain.JumpRise.ConditionInitChildState()) SetChildState(StateContain.JumpRise);
        //    else if (StateContain.Fall.ConditionInitChildState()) SetChildState(StateContain.Fall);
        //    currentChildState.EnterState();
        //}
        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override bool ConditionEnterState()
        {
            return InputTransform.IsJumpPressed && Body.IsOnGround || !Body.IsTerrestrial;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
    }
}
