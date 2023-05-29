namespace StateContent
{
    internal class ScytheAttackStateStore : StateStore
    {
        public ScytheAttackStateStore(IStateContent stateContent) : base(stateContent)
        {

        }

        protected override void CreateStateContain()
        {
            AttackGroup = new AttackScytheGroupState(_stateContent);
            AttackQ = new ScytheAttackQ(_stateContent);
            AttackGroup.AddChildState(AttackQ);
        }

        public IState AttackGroup { get; private set; }

        public IState AttackQ { get; private set; }
    }
}
