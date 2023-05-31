
namespace StateContents
{
    internal class PlayerAirborneState : MovementState
    {
        public PlayerAirborneState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
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
    }
}
