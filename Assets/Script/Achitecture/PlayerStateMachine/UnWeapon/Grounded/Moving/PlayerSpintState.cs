using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerSpintState : PlayerBaseState
    {
        public PlayerSpintState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.AnimationHashs.IsSprintHash;
        }

        public override void CheckUpdateState()
        {
            if(!stateControl.InputPress.IsSpintPressed)
            {
                SwitchState(factoryState.Run());
            }
            else if(!stateControl.InputPress.IsRunPressed)
            {
                SwitchState(factoryState.StopOnGround());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Sprint");
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
            stateControl.MainContent.Physiscal.X_VelocityApplie = stateControl._cameraRelativeMovement.normalized.x * sprintSpeed;
            stateControl.MainContent.Physiscal.Z_VelocityApplie = stateControl._cameraRelativeMovement.normalized.z * sprintSpeed;
        }
    }
}
