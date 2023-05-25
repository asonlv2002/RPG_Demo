
using UnityEngine;

namespace StateMachine
{
    using Input;
    internal class StateInputUnequipAdapter: StateInputAdapter, ITransformInput
    {
        public StateInputUnequipAdapter(PlayerInputAction inputAction) : base(inputAction)
        {
        }

        public bool IsRunPressed => PlayerInput.InputPress.IsRunPressed;

        public bool IsJumpPressed => PlayerInput.InputPress.IsJumpPressed;

        public bool IsSpintPressed => PlayerInput.InputPress.IsSpintPressed;

        public Vector3 CurrentInputMovement => PlayerInput.InputPress.CurrentInputMovement;
    }
}
