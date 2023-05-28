namespace StateMachine
{
    internal class PlayerStopOnGroundState : TransformState
    {
        public PlayerStopOnGroundState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsStopOnGround;
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
            return !InputTransform.IsRunPressed && !InputTransform.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputTransform.IsRunPressed && !InputTransform.IsSpintPressed;
        }
    }
}
