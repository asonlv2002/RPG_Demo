namespace StateContents
{
    internal abstract class MovementState : BaseState
    {
        protected MovementStateStore StateStore;
        protected IInputMovementAdapter InputMovement;
        public MovementState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent)
        {
            StateStore = stateTransition;
            InputMovement = StateContent.GetContentComponent<InputMovementAdapter>();
        }

    }
}
