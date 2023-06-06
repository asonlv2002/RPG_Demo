
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
            if (EnterFriendState(MovementStore.Grounded)) return;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(MovementStore.Fall)) return;
            else if(EnterChildState(MovementStore.JumpRise)) return;

        }
    }
}
