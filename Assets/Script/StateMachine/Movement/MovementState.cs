namespace StateContents
{
    internal abstract class MovementState : BaseState
    {
        protected MovementStateStore MovementStore;
        protected InputMovementAdapter InputMovement;
        public MovementState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent)
        {
            MovementStore = stateTransition;
            InputMovement = StateContent.GetContentComponent<InputMovementAdapter>();
        }

    }
}
