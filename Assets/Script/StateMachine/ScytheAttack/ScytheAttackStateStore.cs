namespace StateContents
{
    internal class ScytheAttackStateStore : StateStore
    {
        public ScytheAttackStateStore(StateCore stateContent) : base(stateContent)
        {

        }

        protected override void CreateStateContain()
        {
            ScytheAttackGroup = new ScytheAttackGroup(_stateContent, this);
            AttackOnGround = new ScytheAttackOnGround(_stateContent,this);
            AttackOnAir = new ScytheAttackOnAir(_stateContent, this);
            AttackQ = new ScytheAttackQ(_stateContent,this);
            AttackE = new ScytheAttackE(_stateContent,this);

            AttackCompoA = new AttackCompoA(_stateContent, this);

            AttackAA = new AttackAA(_stateContent, this);
            AttackAB = new AttackAB(_stateContent, this);
            AttackAC = new AttackAC(_stateContent, this);


        }

        public BaseState ScytheAttackGroup { get; private set; }

        public BaseState AttackOnGround { get; private set; }

        public BaseState AttackOnAir { get; private set; }

        public BaseState AttackQ { get; private set; }

        public BaseState AttackE { get; private set; }

        public BaseState AttackCompoA { get; private set; }
        public BaseState AttackAA { get; private set; }
        public BaseState AttackAB { get; private set; }
        public BaseState AttackAC { get; private set; }

        public BaseState Movement { get; private set; }


        public void AddMovement(BaseState move)
        {
            Movement = move;
        }
    }
}
