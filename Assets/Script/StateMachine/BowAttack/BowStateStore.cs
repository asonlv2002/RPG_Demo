namespace StateContents
{
    internal class BowStateStore : StateStore
    {
        public BowStateStore(StateCore stateContent) : base(stateContent)
        {
        }

        protected override void CreateStateContain()
        {
            BowAttackGroup = new BowAttackGroup(_stateContent, this);
            BowAimGroup = new BowAimGroup(_stateContent, this);

            BowAimLoad = new BowAimLoad(_stateContent, this);
            BowAimHolding = new BowAimHolding(_stateContent, this);
            BowAimReslease = new BowAimRelease(_stateContent, this);

            BowFireGroup = new BowFireGroup(_stateContent, this);
            BowFireOne = new BowFireOne(_stateContent, this);
            BowFireTwo = new BowFireTwo(_stateContent, this);
            BowFireThree = new BowFireThree(_stateContent, this);

        }

        public BaseState BowAttackGroup { get; private set; }
        public BaseState BowAimGroup { get; private set; }
        public BaseState BowAimLoad { get; private set; }
        public BaseState BowAimHolding { get; private set; }
        public BaseState BowAimReslease { get; private set; }

        public BaseState BowFireGroup { get; private set; }
        public BaseState BowFireOne { get; private set; }
        public BaseState BowFireTwo { get; private set; }
        public BaseState BowFireThree { get; private set; }
        public BaseState Movement { get; private set; }

        public void AddMovement(BaseState move)
        {
            Movement = move;
        }

        public override void OnRemoveComponent()
        {
            BowAimGroup = null;
            BowAimLoad = null;
            BowAimReslease = null;
            BowAimHolding = null;
            BowAimLoad = null;
            Movement = null;
        }
    }
}
