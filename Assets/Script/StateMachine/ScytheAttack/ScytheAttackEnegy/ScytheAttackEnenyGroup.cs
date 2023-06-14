namespace StateContents
{
    internal class ScytheAttackEnenyGroup : ScytheAttack
    {
        public ScytheAttackEnenyGroup(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
        }


        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
        }

        public override void UpdateState()
        {
            IsExit = !InputAttack.IsAttackEnegy && ScytheStore.AttackEnegyEnd.IsExit;
            if (IsExit)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackCompoA)) return;
            }
            base.UpdateState();

        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackEnegyStart)) return;
        }
        public override bool ConditionEnterState()
        {
            return ScytheStore.AttackEnegyStart.ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }
    }
}
