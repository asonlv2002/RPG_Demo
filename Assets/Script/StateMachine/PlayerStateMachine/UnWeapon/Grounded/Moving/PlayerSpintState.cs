using UnityEngine;

namespace StateContents
{
    internal class PlayerSpintState : MovementState
    {
        public PlayerSpintState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToFriendState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsSpintPressed;
        }
    }
}
