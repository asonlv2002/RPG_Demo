namespace StateContent
{
    internal class PlayerIdleState : MovementState
    {
        public PlayerIdleState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isIdle");
        }
        public override void EnterState()
        {
            base.EnterState();

            animator.SetBool(ActionParameter, true);
            StopOnGround();
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override bool ConditionEnterState()
        {
            return !InputMovement.IsRunPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputMovement.IsRunPressed;
        }

        private void StopOnGround()
        {
            Physiscal.VelocityApplie = UnityEngine.Vector3.up * Physiscal.Y_VelocityApplie;
        }
    }
}
