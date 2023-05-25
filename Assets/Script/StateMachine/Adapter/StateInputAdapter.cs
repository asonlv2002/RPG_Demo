namespace StateMachine
{
    using Input;
    internal abstract class StateInputAdapter
    {
        protected PlayerInputAction PlayerInput;
        public StateInputAdapter(PlayerInputAction inputAction)
        {
            PlayerInput = inputAction;
        }
    }
}