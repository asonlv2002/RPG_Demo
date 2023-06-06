using UnityEngine;

namespace StateContents
{
    internal class PlayerGroundedState : MovementState
    {
        public PlayerGroundedState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {

        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Airborne)) return;
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
            Body.Rotation(InputMovement.DirectionRotate);
        }
        public override bool ConditionEnterState()
        {
            return Body.IsOnGround &&  StateContent.CurrentState != StateStore.JumpRise;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsTerrestrial;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(StateStore.Idle)) return;
            else if (EnterChildState(StateStore.Move)) return;
        }
    }
}