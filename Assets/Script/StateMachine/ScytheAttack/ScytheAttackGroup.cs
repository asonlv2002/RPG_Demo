namespace StateContents
{
    internal class ScytheAttackGroup : ScytheAttack
    {
        ScytheAnimatorControllerAdapter AnimatorController;
        public ScytheAttackGroup(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            AnimatorController = stateContent.GetContentComponent<ScytheAnimatorControllerAdapter>();
        }
        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            base.EnterState();
        }
        public override bool ConditionEnterState()
        {
            return ScytheStore.AttackOnGround.ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return true;
        }

        public override bool ConditionExitState()
        {
           return currentChildState.ConditionExitState();
        }
    }
}
