using UnityEngine;

namespace StateContent
{
    internal class PlayerMoveState : MovementState
    {
        public PlayerMoveState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isMove");
        }

        public override void EnterState()
        {
            RenderAction(SpeedMove());
            base.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Rotation();
            OnMoving();
            RenderAction(SpeedMove());
        }
        public override void ExitState()
        {
            RenderAction(0);
            base.ExitState();
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

        float SpeedMove()
        {
            return InputMovement.IsSpintPressed ? 4 : 2;
        }

        void OnMoving()
        {
            Physiscal.X_VelocityApplie = InputMovement.CurrentInputMovement.x * SpeedMove();
            Physiscal.Z_VelocityApplie = InputMovement.CurrentInputMovement.z * SpeedMove();
            Physiscal.VelocityApplie *= Physiscal.GetSpeedOnGroundDenpeden(Body.AngleFeetGround);
        }

        void RenderAction(float Speed)
        {
            animator.SetFloat(ActionParameter, Speed);
        }
        public override bool ConditionEnterState()
        {
            return InputMovement.IsRunPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsRunPressed;
        }
    }
}
