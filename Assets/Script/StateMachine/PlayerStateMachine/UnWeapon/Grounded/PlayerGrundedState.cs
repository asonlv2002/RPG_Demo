using UnityEngine;

namespace StateContent
{
    internal class PlayerGroundedState : MovementState
    {
        public PlayerGroundedState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsGroundHash;
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
            return Body.IsOnGround && StateContent.CurrentState != StateStore.JumpRise;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsTerrestrial;
        }
    }
}