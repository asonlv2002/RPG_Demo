using UnityEngine;

namespace StateMachine
{
    internal class PlayerMoveState : PlayerBaseState , IRootState
    {
        public PlayerMoveState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsMoveHash;
        }

        public override void CheckUpdateState()
        {
            if(!stateControl.MainContent.InputAction.InputPress.IsRunPressed)
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
            if(stateControl.MainContent.InputAction.InputPress.IsRunPressed)
            {
                SetChildState(factoryState.Run());
            }
            if(stateControl.MainContent.InputAction.InputPress.IsSpintPressed)
            {
                SetChildState(factoryState.Sprint());
            }
            childState.EnterState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Rotation();
            stateControl.MainContent.Physiscal.VelocityApplie *= stateControl.MainContent.Physiscal.GetSpeedOnGroundDenpeden(stateControl.MainContent.Body.FootTrack.AngleFeetGround);
        }

        private void Rotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = stateControl.MainContent.InputAction.InputPress.CurrentInputMovement.z;

            Quaternion currentRotation = stateControl.MainContent.Body.PlayerTranform.rotation;

            if (stateControl.MainContent.InputAction.InputPress.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                stateControl.MainContent.Body.PlayerTranform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.fixedDeltaTime);
            }
        }

        //private void ConvertDirection()
        //{
        //    stateControl._cameraRelativeMovement = stateControl.ConvertToCameraSpace(stateControl.InputPress.CurrentInputMovement);

        //}
    }
}
