namespace StateContents
{
    internal class PlayerStopOnGroundState : MovementState
    {
        public PlayerStopOnGroundState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            Physiscal.Movement(0, 0);
        }
        public override void UpdateState()
        {
            base.UpdateState();
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
