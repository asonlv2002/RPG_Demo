namespace StateMachine
{
    internal class PlayerStopOnGroundState : TransformState, IRootState
    {
        public PlayerStopOnGroundState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsStopOnGround;
        }

        public override void EnterState()
        {
            base.EnterState();
            InitilationChildrenState();
            StopOnGround();
        }

        public override void SwitchToOtherRoot()
        {
            if (Input.IsRunPressed)
            {
                SwitchState(StateContain.Move);
            }
        }
        public override void UpdateState()
        {
            base.UpdateState();
            SwitchToOtherRoot();
        }

        public void InitilationChildrenState()
        {
            //if (_lastState == StateContain.Sprint())
            //{
            //    SetChildState(StateContain.SprintToIdle());
            //}
            //else
            //{
            //    SetChildState(StateContain.Idle());
            //}
            //stateControl.LastState = null;
            //childState.EnterState();
        }

        private void StopOnGround()
        {
            Physiscal.VelocityApplie = UnityEngine.Vector3.up * Physiscal.Y_VelocityApplie;
        }
    }
}
