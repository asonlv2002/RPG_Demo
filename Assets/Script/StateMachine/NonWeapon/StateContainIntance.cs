namespace StateMachine
{
    internal class StateContainIntance :StateContain , ITransformStateStore
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

        public StateContainIntance(IStateContext stateContext) : base(stateContext)
        {
            LinkChildState();
            LinkFriendState();

        }
        protected override void CreateStateContain()
        {
            Movement = new PlayerMovementState(_stateContext, this);
            Grounded = new PlayerGroundedState(_stateContext, this);
            Airborne = new PlayerAirborneState(_stateContext, this);

            Move = new PlayerMoveState(_stateContext, this);
            Idle = new PlayerIdleState(_stateContext, this);
            Sprint = new PlayerSpintState(_stateContext, this);

            Run = new PlayerRunState(_stateContext, this);
            JumpRise = new PlayerJumpRiseState(_stateContext, this);
            JumpFall = new PlayerJumpFallState(_stateContext, this);

            Fall = new PlayerFallState(_stateContext, this);
            StopOnGround = new PlayerStopOnGroundState(_stateContext, this);
            SprintToIdle = new PlayerSprintToIdleState(_stateContext, this);
        }

        void LinkFriendState()
        {
            Grounded.AddFriendState(Airborne);
            JumpRise.AddFriendState(Fall);
            Move.AddFriendState(StopOnGround);
            StopOnGround.AddFriendState(Move);
            Run.AddFriendState(Sprint);        
        }

        void LinkChildState()
        {
            Movement.AddChildState(Airborne);
            Movement.AddChildState(Grounded);

            Grounded.AddChildState(Move);
            Grounded.AddChildState(StopOnGround);

            Move.AddChildState(Run);
            Move.AddChildState(Sprint);

            StopOnGround.AddChildState(Idle);

            Airborne.AddChildState(JumpRise);
            Airborne.AddChildState(Fall);
        }
    }
}
