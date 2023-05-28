namespace StateMachine
{
    internal interface IState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        bool ConditionEnterState();
        bool ConditionInitChildState();
        void AddFriendState(IState friendState);
        void AddChildState(IState chiSate);
    }
}
