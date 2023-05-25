namespace StateMachine
{
    internal interface IState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
    }
}
