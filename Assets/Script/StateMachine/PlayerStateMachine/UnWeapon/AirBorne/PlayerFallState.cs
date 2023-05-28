using UnityEngine;
namespace StateMachine
{
    internal class PlayerFallState : TransformState
    {
        public PlayerFallState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsFallHash;
        }

        //public override void SwitchToFriendState()
        //{
            
        //}

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
            return Physiscal.Y_VelocityApplie < 0f;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
    }
}
