using UnityEngine;

namespace StateMachine
{
    internal class PlayerMoveState : TransformState
    {
        public PlayerMoveState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsMoveHash;
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
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

        public override bool ConditionEnterState()
        {
            return InputTransform.IsRunPressed || InputTransform.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputTransform.IsRunPressed || InputTransform.IsSpintPressed;
        }
    }
}
