namespace StateContents
{
    internal interface IState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        bool ConditionEnterState();
        bool ConditionInitChildState();
        void InitilationChildrenState();
    }
}
