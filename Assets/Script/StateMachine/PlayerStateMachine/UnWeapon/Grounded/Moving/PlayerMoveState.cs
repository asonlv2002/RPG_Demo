using UnityEngine;

namespace StateContent
{
    internal class PlayerMoveState : MovementState
    {
        public PlayerMoveState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsMoveHash;
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

            postionToLookAt.x = InputMovement.CurrentInputMovement.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = InputMovement.CurrentInputMovement.z;

            Quaternion currentRotation = Body.PlayerTransform.rotation;

            if (InputMovement.IsRunPressed)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                Body.PlayerTransform.rotation = Quaternion.Slerp(currentRotation, targetRoation, 20f * Time.fixedDeltaTime);
            }
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsRunPressed || InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsRunPressed || InputMovement.IsSpintPressed;
        }
    }
}
