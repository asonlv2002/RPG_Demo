
namespace StateMachine
{
    internal class PlayerAirborneState : TransformState, IRootState
    {
        public PlayerAirborneState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsAirborneHash;
        }

        public override void SwitchToOtherRoot()
        {
            if(Body.IsOnGround && childState != StateContain.JumpRise)
            {
                SwitchState(StateContain.Grounded);
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            InitilationChildrenState();
        }

        public void InitilationChildrenState()
        {
            if(Input.IsJumpPressed)
            {
                SetChildState(StateContain.JumpRise);
            }
            else
            {
                SetChildState(StateContain.Fall);
            }
            childState.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            SwitchToOtherRoot();

        }
    }
}
