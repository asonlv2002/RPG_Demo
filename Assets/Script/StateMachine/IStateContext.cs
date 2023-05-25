
namespace StateMachine
{
    internal interface IStateContext
    {
        IStateContain StateProvider { get; }
        IState CurrentState { get; set; }
    }
}
