using UnityEngine;

namespace StateMachine
{
    internal class PlayerSpintState : PlayerBaseState
    {
        public PlayerSpintState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsSprintHash;
        }

        public override void CheckUpdateState()
        {
            if(!stateControl.MainContent.InputAction.InputPress.IsSpintPressed)
            {
                SwitchState(factoryState.Run());
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
            Sprint();
        }

        private void Sprint()
        {
            float sprintSpeed = stateControl.MainContent.Physiscal.PhysiscVariable.SprintSpeed;
            stateControl.MainContent.Physiscal.X_VelocityApplie = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.x * sprintSpeed;
            stateControl.MainContent.Physiscal.Z_VelocityApplie = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.z * sprintSpeed  ;
        }
    }
}
