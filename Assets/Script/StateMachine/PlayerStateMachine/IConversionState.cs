
namespace StateMachine
{
    internal interface IConversionState
    {
        float TimeExitState { get; }
        void CalculatorTimeExit();
    }
}
