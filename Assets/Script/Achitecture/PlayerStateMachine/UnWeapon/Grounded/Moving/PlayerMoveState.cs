using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerMoveState : PlayerBaseState , IRootState
    {
        public PlayerMoveState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.AnimationHashs.IsMoveHash;
        }

        public override void CheckUpdateState()
        {
            if(!stateControl.InputPress.IsRunPressed)
            {
                SwitchState(factoryState.StopOnGround());
            }
        }
        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Moving");
            InitializationSubState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }

        public void InitializationSubState()
        {
            if(stateControl.InputPress.IsRunPressed)
            {
                SetChildState(factoryState.Run());
            }
            if(stateControl.InputPress.IsSpintPressed)
            {
                SetChildState(factoryState.Sprint());
            }
            childState.EnterState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            ConvertDirection();
            Rotation();
            stateControl.MainContent.Physiscal.VelocityApplie *= stateControl.MainContent.Physiscal.GetSpeedOnGroundDenpeden(stateControl.MainContent.Body.FootTrack.AngleFeetGround);
        }

        private void Rotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = stateControl._cameraRelativeMovement.normalized.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = stateControl._cameraRelativeMovement.normalized.z;

            Quaternion currentRotation = stateControl.MainContent.Body.PlayerTranform.rotation;

            if (stateControl.InputPress.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                stateControl.MainContent.Body.PlayerTranform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.fixedDeltaTime);
            }
        }

        private void ConvertDirection()
        {
            stateControl._cameraRelativeMovement = stateControl.ConvertToCameraSpace(stateControl.InputPress.CurrentInputMovement);
            
        }
    }
}
