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
        public override void UpdateState()
        {
            base.UpdateState();
            if (ScytheStore.AttackOnGround.IsExit && ScytheStore.AttackOnAir.IsExit)
            {
                if (EnterFriendState(ScytheStore.Movement)) return;
            }
        }
        public override bool ConditionInitChildState()
        {
            return true;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackOnGround)) return;
        }
    }
}
