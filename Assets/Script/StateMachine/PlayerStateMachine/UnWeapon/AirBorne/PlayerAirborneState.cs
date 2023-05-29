
namespace StateContent
{
    internal class PlayerAirborneState : MovementState
    {
        public PlayerAirborneState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsAirborneHash;
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
            return InputMovement.IsJumpPressed && Body.IsOnGround || !Body.IsTerrestrial;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
    }
}
