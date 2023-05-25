namespace StateMachine
{
    internal interface IStateBodyProvider
    {
        IStateBodyAdapter Body { get; }
    }
}
