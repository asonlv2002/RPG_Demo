namespace StateMachine
{
    using InputContent;
    internal abstract class StateInputAdapter
    {
        protected PlayerInputAction PlayerInput;
        public StateInputAdapter(PlayerInputAction inputAction)
        {
            PlayerInput = inputAction;
        }
    }
}