
namespace StateContents
{
    internal class PlayerAirborneState : MovementState
    {
        public PlayerAirborneState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {

        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsJumpPressed && Body.IsOnGround || !Body.IsTerrestrial;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Grounded)) return;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(StateStore.Fall)) return;
            else if(EnterChildState(StateStore.JumpRise)) return;

        }
    }
}
