
namespace Achitecture.StateMachine
{
    internal class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.AnimationHashs.IsRunHash;
        }

        public override void CheckUpdateState()
        {
            if(stateControl.InputPress.IsRunPressed && stateControl.InputPress.IsSpintPressed)
            {
                SwitchState(factoryState.Sprint());
            }
            else if(!stateControl.InputPress.IsRunPressed)
            {
                SwitchState(factoryState.StopOnGround());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("Run");
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
            stateControl.MainContent.Physiscal.X_VelocityApplie = stateControl._cameraRelativeMovement.normalized.x * speedRun;
            stateControl.MainContent.Physiscal.Z_VelocityApplie = stateControl._cameraRelativeMovement.normalized.z * speedRun;
        }
    }
}
