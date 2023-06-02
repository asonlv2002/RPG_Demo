using UnityEngine;

namespace StateContents
{
    internal class PlayerJumpRiseState : MovementState
    {
        public PlayerJumpRiseState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isJumpUp");
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            Physiscal.Jump(1);
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Fall)) return;
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.GravityEffect(100f);
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsJumpPressed && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsJumpPressed;
        }
    } 
}
