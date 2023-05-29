namespace StateContent
{
    internal class PlayerStopOnGroundState : MovementState
    {
        public PlayerStopOnGroundState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsStopOnGround;
        }

        public override void EnterState()
        {
            base.EnterState();
            StopOnGround();
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }

        private void StopOnGround()
        {
            Physiscal.VelocityApplie = UnityEngine.Vector3.up * Physiscal.Y_VelocityApplie;
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
