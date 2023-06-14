namespace StateContents
{

    internal class BowFireGroup : BowAttack
    {
        public BowFireGroup(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
        }

        public override void EnterState()
        {

            IsExit = false;
            base.EnterState();
        }
        public override void UpdateState()
        {
            IsExit = BowStore.BowFireOne.IsExit && BowStore.BowFireTwo.IsExit && BowStore.BowFireThree.IsExit;
            base.UpdateState();

        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
        }
        public override bool ConditionEnterState()
        {
            return BowStore.BowFireOne.ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return BowStore.BowFireOne.ConditionInitChildState();
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(BowStore.BowFireOne)) return;
        }
    }
}
