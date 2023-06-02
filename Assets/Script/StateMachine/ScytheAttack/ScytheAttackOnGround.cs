namespace StateContents
{
    internal class ScytheAttackOnGround : ScytheAttack
    {

        public ScytheAttackOnGround(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent,Store)
        {

        }
        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(ScytheStore.AttackCompoA.IsExit && ScytheStore.AttackE.IsExit)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackOnAir)) return;
            }
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }
        public override bool ConditionEnterState()
        {
            return ScytheStore.AttackCompoA.ConditionInitChildState() || ScytheStore.AttackE.ConditionEnterState();
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackCompoA)) return;
            else if(EnterChildState(ScytheStore.AttackE)) return;
        }
    }
}
