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
            Physiscal.FloatOnGround(Body.FLoatDirection);
        }
        public override bool ConditionEnterState()
        {
            return Body.IsOnGround &&  StateContent.CurrentState != StateStore.JumpRise;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsTerrestrial;
        }
    }
}