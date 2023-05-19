
namespace StateMachine
{
    internal class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsRunHash;
        }

        public override void CheckUpdateState()
        {
            if(stateControl.MainContent.InputAction.InputPress.IsRunPressed && stateControl.MainContent.InputAction.InputPress.IsSpintPressed)
            {
                SwitchState(factoryState.Sprint());
            }
            else if(!stateControl.MainContent.InputAction.InputPress.IsRunPressed)
            {
                SwitchState(factoryState.StopOnGround());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Run();
        }

        private void Run()
        {
            float speedRun = stateControl.MainContent.Physiscal.PhysiscVariable.RunSpeed;
            stateControl.MainContent.Physiscal.X_VelocityApplie = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.x*speedRun;
            stateControl.MainContent.Physiscal.Z_VelocityApplie = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.z*speedRun;
        }
    }
}
