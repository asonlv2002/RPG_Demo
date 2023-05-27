
namespace StateMachine
{
    internal class PlayerRunState : TransformState
    {
        public PlayerRunState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsRunHash;
        }

        public override void SwitchToOtherRoot()
        {
            if(InputTransform.IsRunPressed && InputTransform.IsSpintPressed)
            {
                SwitchState(StateContain.Sprint);
            }
            else if(!InputTransform.IsRunPressed)
            {
                SwitchState(StateContain.StopOnGround);
            }
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToOtherRoot();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Run();
        }

        private void Run()
        {
            float speedRun = 2f;
            Physiscal.X_VelocityApplie = InputTransform.CurrentInputMovement.x*speedRun;
            Physiscal.Z_VelocityApplie = InputTransform.CurrentInputMovement.z*speedRun;
        }
    }
}
