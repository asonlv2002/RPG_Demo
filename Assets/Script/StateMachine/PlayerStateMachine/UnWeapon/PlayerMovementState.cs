using UnityEngine;
namespace StateContents
{
    internal class PlayerMovementState : MovementState
    {
        MovementAnimatorControllerAdapter AnimatorMovementController;
        public PlayerMovementState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            
            ActionParameter = 0;
        }

        public override void EnterState()
        {
            AnimatorMovementController = StateContent.GetContentComponent<MovementAnimatorControllerAdapter>();
            AnimatorMovementController?.EnterAnimatorMovement();
            base.EnterState();
        }

        public override bool ConditionEnterState()
        {
            return StateStore.Grounded.ConditionInitChildState() || StateStore.Airborne.ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return true;
        }
    }
}
