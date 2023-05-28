using UnityEngine;
namespace StateMachine
{
    internal class PlayerJumpFallState : TransformState
    {
        public PlayerJumpFallState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsJumpFallHash;
        }

        //public override void SwitchToFriendState()
        //{
        //    //if (stateControl.GroundPos.y <= -5 /*(stateControl.HeightGroundBeginJump - stateControl.CharacterHeight/2)*/)
        //    //{
        //    //    SwitchState(StateContain.Fall());
        //    //}
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
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
