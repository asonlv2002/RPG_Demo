
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
            if(Input.IsRunPressed && Input.IsSpintPressed)
            {
                SwitchState(StateContain.Sprint);
            }
            else if(!Input.IsRunPressed)
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
            Physiscal.X_VelocityApplie = Input.CurrentInputMovement.x*speedRun;
            Physiscal.Z_VelocityApplie = Input.CurrentInputMovement.z*speedRun;
        }
    }
}
