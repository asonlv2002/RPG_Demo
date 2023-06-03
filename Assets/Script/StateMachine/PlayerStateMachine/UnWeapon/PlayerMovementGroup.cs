using UnityEngine;
namespace StateContents
{
    internal class PlayerMovementGroup : MovementState
    {
        MovementAnimatorControllerAdapter AnimatorMovementController;

        public PlayerMovementGroup(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorMovementController = StateContent.GetContentComponent<MovementAnimatorControllerAdapter>();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.AttackState)) return;
        }
        public override void EnterState()
        {
            
            AnimatorMovementController.EnterAnimatorMovement();
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
