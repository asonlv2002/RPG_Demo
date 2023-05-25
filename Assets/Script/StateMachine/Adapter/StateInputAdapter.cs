
using UnityEngine;

namespace StateMachine
{
    using Input;
    internal class StateInputAdapter : IStateInputAdapter
    {
        PlayerInputAction PlayerInput;
        public StateInputAdapter(PlayerInputAction input)
        {
            PlayerInput = input;
        }
        public bool IsRunPressed => PlayerInput.InputPress.IsRunPressed;

        public bool IsJumpPressed => PlayerInput.InputPress.IsJumpPressed;

        public bool IsSpintPressed => PlayerInput.InputPress.IsSpintPressed;

        public Vector3 CurrentInputMovement => PlayerInput.InputPress.CurrentInputMovement;
    }
}
