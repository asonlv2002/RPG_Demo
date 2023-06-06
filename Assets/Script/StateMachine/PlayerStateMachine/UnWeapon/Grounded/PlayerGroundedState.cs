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
            if (EnterFriendState(MovementStore.Airborne)) return;
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
            Body.Rotation(InputMovement.DirectionRotate);
        }
        public override bool ConditionEnterState()
        {
            return Body.IsOnGround &&  StateContent.CurrentState != MovementStore.JumpRise;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsTerrestrial;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(MovementStore.Idle)) return;
            else if (EnterChildState(MovementStore.Move)) return;
        }
    }
}