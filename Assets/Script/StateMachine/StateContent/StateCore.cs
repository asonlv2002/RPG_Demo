namespace StateContents
{
    internal abstract class StateCore : Achitecture.CoreContain<StateComponent>
    {
        public IState CurrentState { get; set; }

        public void EnterNextState(IState nextState)
        {
            CurrentState = nextState;
            CurrentState.EnterState();
            CurrentState.InitilationChildrenState();
        }
    }
}
