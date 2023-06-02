namespace StateContents
{
    internal abstract class StateCore : Achitecture.CoreContain<StateComponent>
    {
        public BaseState CurrentState { get; set; }

        public void EnterNextState(BaseState nextState)
        {
            CurrentState = nextState;
            CurrentState.EnterState();
            CurrentState.InitilationChildrenState();
        }
    }
}
