namespace StateContents
{
    internal interface IState
    {
        int IndexPriorityFriend { get; }
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        bool ConditionEnterState();
        bool ConditionInitChildState();
        void AddFriendState(IState friendState);
        void AddChildState(IState chiSate);
        bool ConditionExitState();
        void InitilationChildrenState();
    }
}
