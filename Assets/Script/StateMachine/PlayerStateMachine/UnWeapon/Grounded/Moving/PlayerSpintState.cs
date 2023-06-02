using UnityEngine;

namespace StateContents
{
    internal class PlayerSpintState : MovementState
    {
        public PlayerSpintState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
        }

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
