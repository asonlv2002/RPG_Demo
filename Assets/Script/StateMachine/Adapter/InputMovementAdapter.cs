
using UnityEngine;

namespace StateContent
{
    using InputContent;
    internal class InputMovementAdapter: StateComponent, IInputMovementAdapter
    {
        InputMovement InputMovement;
        public InputMovementAdapter(IInputContent inputContent)
        {
            InputMovement = inputContent.GetContentComponent<InputMovement>();
        }

        public bool IsRunPressed => InputMovement.IsRunPressed;

        public bool IsJumpPressed => InputMovement.IsJumpPressed;

        public bool IsSpintPressed => InputMovement.IsSpintPressed;

        public Vector3 CurrentInputMovement => InputMovement.CurrentInputMovement;
    }
}
