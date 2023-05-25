
namespace StateMachine
{
    internal interface IStateContext
    {
        StateContain StateProvider { get; }
        IState CurrentState { get; set; }
    }
}
