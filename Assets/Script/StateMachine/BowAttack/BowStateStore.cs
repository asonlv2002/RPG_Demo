namespace StateContents
{
    internal class BowStateStore : StateStore
    {
        public BowStateStore(StateCore stateContent) : base(stateContent)
        {
        }

        protected override void CreateStateContain()
        {
            AimShootGroup = new BowAttackAimShootGroup(_stateContent, this);

            AimShootLoad = new BowAimShootLoad(_stateContent, this);
            AimShootHolding = new BowAimShootHolding(_stateContent, this);
            AimShootReslease = new BowAimShootRelease(_stateContent, this);

        }

        public BaseState AimShootGroup { get; private set; }
        public BaseState AimShootLoad { get; private set; }
        public BaseState AimShootHolding { get; private set; }
        public BaseState AimShootReslease { get; private set; }
        public BaseState Movement { get; private set; }

        public void AddMovement(BaseState move)
        {
            Movement = move;
        }

        public override void OnRemoveComponent()
        {
            AimShootGroup = null;
            AimShootLoad = null;
            AimShootReslease = null;
            AimShootHolding = null;
            AimShootLoad = null;
            Movement = null;
        }
    }
}
