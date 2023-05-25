
namespace StateMachine
{
    internal interface IStateInputProvider
    {
        IStateInputAdapter Input { get; }
    }
}
