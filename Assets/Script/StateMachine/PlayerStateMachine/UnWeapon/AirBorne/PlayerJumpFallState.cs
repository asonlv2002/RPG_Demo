using UnityEngine;
namespace StateContent
{
    internal class PlayerJumpFallState : MovementState
    {
        public PlayerJumpFallState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isJumpFall");
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
            GravityEffect();
        }
        private void GravityEffect()
        {
            float gravity = Physiscal.Gravity;
            float oldYVelocity = Physiscal.Y_VelocityApplie;
            float newYVelocity = Physiscal.Y_VelocityApplie + gravity * 2f * Time.fixedDeltaTime;
            Physiscal.Y_VelocityApplie = (oldYVelocity + newYVelocity) / 2f;
        }

        public override bool ConditionEnterState()
        {
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
