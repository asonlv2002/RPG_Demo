using UnityEngine;

namespace StateMachine
{
    internal class PlayerGroundedState : TransformState
    {
        public PlayerGroundedState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsGroundHash;
        }

        //public override void SwitchToFriendState()
        //{
        //    if (StateContain.Airborne.ConditionEnterState()) SwitchState(StateContain.Airborne);
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
            FloatBodyOnGround();
        }

        private void FloatBodyOnGround()
        {
            var constFeet = Physiscal.ConstFeet;
            Physiscal.Y_VelocityApplie = Body.FLoatDirection* constFeet;
        }

        public override bool ConditionEnterState()
        {
            return Body.IsOnGround && StateContext.CurrentState != StateContain.JumpRise;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsTerrestrial;
        }
    }
}