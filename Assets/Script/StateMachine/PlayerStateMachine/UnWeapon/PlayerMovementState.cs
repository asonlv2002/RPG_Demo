using UnityEngine;
namespace StateContents
{
    internal class PlayerMovementState : MovementState
    {
        MovementAnimatorControllerAdapter AnimatorMovementController;

        public PlayerMovementState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {

        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.AttackState)) return;
        }
        public override void EnterState()
        {
            AnimatorMovementController = StateContent.GetContentComponent<MovementAnimatorControllerAdapter>();
            AnimatorMovementController?.EnterAnimatorMovement();
            animator.applyRootMotion = false;
            base.EnterState();
        }

        public override bool ConditionEnterState()
        {
            return StateStore.Grounded.ConditionInitChildState() || StateStore.Airborne.ConditionInitChildState();
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(StateStore.Grounded)) return;
            else if (EnterChildState(StateStore.Airborne)) return;
        }
    }
}
