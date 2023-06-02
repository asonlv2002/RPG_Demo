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
            animator.applyRootMotion = true;
            Physiscal.Movement(0, 0);
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (ScytheStore.AttackOnGround.IsExit && ScytheStore.AttackOnAir.IsExit)
            {
                if (EnterFriendState(ScytheStore.Movement)) return;
            }
        }
        public override void ExitState()
        {
            animator.applyRootMotion = false;
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return true;
        }
        public override bool ConditionEnterState()
        {
            return ScytheStore.AttackOnGround.ConditionInitChildState() || ScytheStore.AttackOnAir.ConditionInitChildState();
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackOnGround)) return;
            else if (EnterChildState(ScytheStore.AttackOnAir)) return;
        }
    }
}
