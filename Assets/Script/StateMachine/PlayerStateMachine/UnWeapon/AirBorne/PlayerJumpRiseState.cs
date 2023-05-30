using UnityEngine;

namespace StateContent
{
    internal class PlayerJumpRiseState : MovementState
    {
        public PlayerJumpRiseState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isJumpUp");
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            Jump();
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            GravityEffect();
        }

        private void Jump()
        {
            Physiscal.Y_VelocityApplie = Physiscal.JumpHeight;
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            base.ExitState();
        }

        private void GravityEffect()
        {
            var gravity = Physiscal.Gravity;
            var oldYVelocity = Physiscal.Y_VelocityApplie;
            var newVelocityY = Physiscal.Y_VelocityApplie + gravity * Time.deltaTime;
            Physiscal.Y_VelocityApplie = (oldYVelocity + newVelocityY) * .5f;
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsJumpPressed && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsJumpPressed;
        }
    } 
}
