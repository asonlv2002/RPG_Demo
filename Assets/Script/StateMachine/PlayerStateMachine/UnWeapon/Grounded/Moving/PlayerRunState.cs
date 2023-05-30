
namespace StateContents
{
    internal class PlayerRunState : MovementState
    {
        public PlayerRunState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Run();
        }

        private void Run()
        {
            float speedRun = 2f;
            Physiscal.X_VelocityApplie = InputMovement.CurrentInputMovement.x*speedRun;
            Physiscal.Z_VelocityApplie = InputMovement.CurrentInputMovement.z*speedRun;
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsRunPressed && !InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsRunPressed;
        }
    }
}
