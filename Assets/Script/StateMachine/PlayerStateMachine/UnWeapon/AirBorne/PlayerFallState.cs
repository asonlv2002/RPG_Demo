using UnityEngine;
namespace StateContent
{
    internal class PlayerFallState : MovementState
    {
        public PlayerFallState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsFallHash;
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
            return Physiscal.Y_VelocityApplie < 0f;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
    }
}
