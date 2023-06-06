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
            if (EnterFriendState(MovementStore.AttackState)) return;
        }
        public override void EnterState()
        {
            
            AnimatorMovementController.EnterAnimatorMovement();
            animator.applyRootMotion = false;
            base.EnterState();
        }

        public override bool ConditionEnterState()
        {
            return MovementStore.Grounded.ConditionInitChildState() || MovementStore.Airborne.ConditionInitChildState();
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(MovementStore.Grounded)) return;
            else if (EnterChildState(MovementStore.Airborne)) return;
        }
    }
}
