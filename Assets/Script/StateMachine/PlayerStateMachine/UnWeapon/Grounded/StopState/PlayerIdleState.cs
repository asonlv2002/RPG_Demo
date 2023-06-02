namespace StateContents
{
    internal class PlayerIdleState : MovementState
    {
        public PlayerIdleState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isIdle");
        }
        public override void EnterState()
        {
            base.EnterState();

            animator.SetBool(ActionParameter, true);
            Physiscal.Movement(0, 0);
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Move)) return;
        }

        public override bool ConditionEnterState()
        {
            return !InputMovement.IsRunPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputMovement.IsRunPressed;
        }
    }
}
