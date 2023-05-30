namespace StateContents
{
    internal interface IMovementStateStore
    {
        public IState Movement { get;}
        public IState Grounded { get; }
        public IState Idle { get; }
        public IState Move { get; }
        public IState Airborne { get; }
        public IState JumpRise { get; }
        public IState Fall { get; }
    }
}
