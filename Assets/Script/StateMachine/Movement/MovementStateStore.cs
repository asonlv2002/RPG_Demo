namespace StateContent
{
    internal class MovementStateStore :StateStore , IMovementStateStore
    {
        public IState Movement {get; private set;}

        public IState Grounded {get; private set;}

        public IState Idle {get; private set;}

        public IState Move {get; private set;}

        public IState Run {get; private set;}

        public IState Sprint {get; private set;}

        public IState Airborne {get; private set;}

        public IState JumpRise {get; private set;}

        public IState JumpFall {get; private set;}

        public IState Fall {get; private set;}

        public IState SprintToIdle {get; private set;}

        public IState StopOnGround {get; private set;}

        public MovementStateStore(IStateContent stateContext) : base(stateContext)
        {
            LinkChildState();
            LinkFriendState();

        }
        protected override void CreateStateContain()
        {
            Movement = new PlayerMovementState(_stateContent, this);
            Grounded = new PlayerGroundedState(_stateContent, this);
            Airborne = new PlayerAirborneState(_stateContent, this);

            Move = new PlayerMoveState(_stateContent, this);
            Idle = new PlayerIdleState(_stateContent, this);

            JumpRise = new PlayerJumpRiseState(_stateContent, this);
            JumpFall = new PlayerJumpFallState(_stateContent, this);

            Fall = new PlayerFallState(_stateContent, this);
        }

        void LinkFriendState()
        {
            Grounded.AddFriendState(Airborne);
            JumpRise.AddFriendState(Fall);
            Move.AddFriendState(Idle);      
        }

        void LinkChildState()
        {
            Movement.AddChildState(Airborne);
            Movement.AddChildState(Grounded);

            Grounded.AddChildState(Move);
            Grounded.AddChildState(Idle);

            Airborne.AddChildState(JumpRise);
            Airborne.AddChildState(Fall);
        }
    }
}
