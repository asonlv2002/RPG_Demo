namespace StateContents
{
    internal abstract class StateCore : Achitecture.CoreContain<StateComponent>
    {
        public IState CurrentState { get; set; }
    }
}
