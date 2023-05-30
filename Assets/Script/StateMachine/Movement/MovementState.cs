namespace StateContent
{
    internal abstract class MovementState : BaseState
    {
        protected IMovementStateStore StateStore;
        protected IInputMovementAdapter InputMovement;
        public MovementState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent)
        {
            StateStore = stateTransition;
            InputMovement = StateContent.GetContentComponent<InputMovementAdapter>();
        }

    }
}
