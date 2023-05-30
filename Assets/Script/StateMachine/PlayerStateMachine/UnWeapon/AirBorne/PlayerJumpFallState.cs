using UnityEngine;

namespace StateContents
{
    using PhysicContents;
    internal class PlayerJumpFallState : MovementState
    {
        public PlayerJumpFallState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isJumpFall");
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
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
