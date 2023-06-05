namespace StateContents
{
    internal class BowAttack : BaseState
    {
        protected BowStateStore BowStore;
        protected InputBowAttackAdapater InputAttack;
        public BowAttack(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent)
        {
            BowStore = bowStateStore;
            InputAttack = StateContent.GetContentComponent<InputBowAttackAdapater>();
        }
    }
}
