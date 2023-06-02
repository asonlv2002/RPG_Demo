using UnityEngine;

namespace StateContents
{
    internal class PlayerMoveState : MovementState
    {
        public PlayerMoveState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isMove");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Idle)) return;
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.applyRootMotion = false;
            RenderAction(SpeedMove());
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Rotation();
            Physiscal.Movement(InputMovement.CurrentInputMovement.x * SpeedMove(),InputMovement.CurrentInputMovement.z * SpeedMove());
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
