namespace StateContents
{
    internal class ScytheAttackStateStore : StateStore
    {
        public ScytheAttackStateStore(StateCore stateContent) : base(stateContent)
        {

        }

        protected override void CreateStateContain()
        {
            ScytheGroup = new ScytheAttackGroup(_stateContent, this);
            AttackOnGround = new ScytheAttackOnGround(_stateContent,this);
            AttackQ = new ScytheAttackQ(_stateContent,this);
            AttackE = new ScytheAttackE(_stateContent,this);
            ScytheGroup.AddChildState(AttackOnGround);
            AttackOnGround.AddChildState(AttackQ);
            AttackOnGround.AddChildState(AttackE);
        }

        public IState ScytheGroup { get; private set; }

        public IState AttackOnGround { get; private set; }

        public IState AttackQ { get; private set; }

        public IState AttackE { get; private set; }
    }
}
