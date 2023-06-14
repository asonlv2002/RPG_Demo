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

            AttackCompoA = new ScytheAttackCompo(_stateContent, this);

            AttackAA = new ScytheAttackOne(_stateContent, this);
            AttackAB = new ScytheAttackTwo(_stateContent, this);
            AttackAC = new ScytheAttackThree(_stateContent, this);

            AttackEnegyGroup = new ScytheAttackEnenyGroup(_stateContent, this);
            AttackEnegyStart = new ScytheAttackEnenyStart(_stateContent, this);
            AttackEnegyMid = new ScytheAttackEnegyMid(_stateContent, this);
            AttackEnegyEnd = new ScytheAttackEnegyEnd(_stateContent, this);

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
        public BaseState AttackEnegyGroup { get; private set; }
        public BaseState AttackEnegyStart { get; private set; }
        public BaseState AttackEnegyMid { get; private set; }
        public BaseState AttackEnegyEnd { get; private set; }


        public void AddMovement(BaseState move)
        {
            Movement = move;
        }
    }
}
