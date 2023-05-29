namespace StateContent
{
    internal class PlayerIdleState : MovementState
    {
        public PlayerIdleState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsIdleHash;
        }

        public override bool ConditionEnterState()
        {
            return !InputMovement.IsRunPressed && !InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputMovement.IsRunPressed && !InputMovement.IsSpintPressed;
        }
    }
}
