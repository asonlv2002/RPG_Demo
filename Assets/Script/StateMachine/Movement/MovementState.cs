namespace StateContents
{
    internal abstract class MovementState : BaseState
    {
        protected MovementStateStore MovementStore;
        protected InputMovementAdapter InputMovement;
        protected PhysicAdapter Physiscal;
        protected BodyAdapter Body;
        public MovementState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent)
        {
            MovementStore = stateTransition;
            InputMovement = StateContent.GetContentComponent<InputMovementAdapter>();
            Physiscal = StateContent.GetContentComponent<PhysicAdapter>();
            Body = StateContent.GetContentComponent<BodyAdapter>();
        }

    }
}
