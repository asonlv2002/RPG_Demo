namespace StateContents
{
    internal class ScytheAttackStateStore : StateStore
    {
        public ScytheAttackStateStore(StateCore stateContent) : base(stateContent)
        {

        }

        protected override void CreateStateContain()
        {
            AttackOnGround = new ScytheAttackOnGround(_stateContent);
            AttackQ = new ScytheAttackQ(_stateContent);
            AttackE = new ScytheAttackE(_stateContent);

            AttackOnGround.AddChildState(AttackQ);
            AttackOnGround.AddChildState(AttackE);

            AttackQ.AddFriendState(AttackE);
        }

        public IState AttackOnGround { get; private set; }

        public IState AttackQ { get; private set; }

        public IState AttackE { get; private set; }
    }
}
