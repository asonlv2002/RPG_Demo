namespace StateContents
{
    internal class BowAttack : BaseState
    {
        protected BowStateStore BowStore;
        protected InputBowAttackAdapater InputAttack;
        protected PhysicAdapter Physiscal;
        protected BodyAdapter Body;
        public BowAttack(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent)
        {
            BowStore = bowStateStore;
            InputAttack = StateContent.GetContentComponent<InputBowAttackAdapater>();
            Physiscal = StateContent.GetContentComponent<PhysicAdapter>();
            Body = StateContent.GetContentComponent<BodyAdapter>();
        }
    }
}
