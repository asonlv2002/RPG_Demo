namespace StateContent
{
    internal interface IStateContent  : Achitecture.IContent<StateComponent>
    {
        IState CurrentState { get; set; }
    }
}
