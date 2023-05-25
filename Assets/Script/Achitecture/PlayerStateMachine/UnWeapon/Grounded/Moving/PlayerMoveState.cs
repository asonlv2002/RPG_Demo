using UnityEngine;

namespace StateMachine
{
    internal class PlayerMoveState : TransformState , IRootState
    {
        public PlayerMoveState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsMoveHash;
        }

        public override void SwitchToOtherRoot()
        {
            if(!InputTransform.IsRunPressed)
            {
                SwitchState(StateContain.StopOnGround);
            }
        }
        public override void EnterState()
        {
            base.EnterState();
            InitilationChildrenState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToOtherRoot();
        }

        public void InitilationChildrenState()
        {
            if(InputTransform.IsRunPressed)
            {
                SetChildState(StateContain.Run);
            }
            if(InputTransform.IsSpintPressed)
            {
                SetChildState(StateContain.Sprint);
            }
            childState.EnterState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Rotation();
            Physiscal.VelocityApplie *= Physiscal.GetSpeedOnGroundDenpeden(Body.AngleFeetGround);
        }

        private void Rotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = InputTransform.CurrentInputMovement.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = InputTransform.CurrentInputMovement.z;

            Quaternion currentRotation = Body.PlayerTransform.rotation;

            if (InputTransform.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                Body.PlayerTransform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.fixedDeltaTime);
            }
        }

    }
}
