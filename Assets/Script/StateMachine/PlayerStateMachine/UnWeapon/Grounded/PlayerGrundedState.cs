using UnityEngine;

namespace StateContents
{
    internal class PlayerGroundedState : MovementState
    {
        public PlayerGroundedState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
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