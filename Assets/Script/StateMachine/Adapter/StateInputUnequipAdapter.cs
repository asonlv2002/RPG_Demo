
using UnityEngine;

namespace StateMachine
{
    using InputContent;
    internal class StateInputUnequipAdapter: StateInputAdapter, ITransformInput
    {
        public StateInputUnequipAdapter(PlayerInputAction inputAction) : base(inputAction)
        {
        }

        public bool IsRunPressed => PlayerInput.GetContentComponet<InputMovement>().IsRunPressed;

        public bool IsJumpPressed => PlayerInput.GetContentComponet<InputMovement>().IsJumpPressed;

        public bool IsSpintPressed => PlayerInput.GetContentComponet<InputMovement>().IsSpintPressed;

        public Vector3 CurrentInputMovement => PlayerInput.GetContentComponet<InputMovement>().CurrentInputMovement;
    }
}
