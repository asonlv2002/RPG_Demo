namespace StateContent
{
    internal interface IMovementStateStore
    {
        public IState Movement { get;}
        public IState Grounded { get; }
        public IState Idle { get; }
        public IState Move { get; }
        public IState Run { get; }
        public IState Sprint { get; }
        public IState Airborne { get; }
        public IState JumpRise { get; }
        public IState JumpFall { get; }
        public IState Fall { get; }
        public IState SprintToIdle { get; }
        public IState StopOnGround { get; }
    }
}
