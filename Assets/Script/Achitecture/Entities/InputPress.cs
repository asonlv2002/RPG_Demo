
using UnityEngine;
using UnityEngine.InputSystem;
namespace Input
{
    [System.Serializable]
    internal class InputPress
    {
        private PlayerInput _playerInput;
        private bool _isMovementPresesd;
        private bool _isJumpPressed;
        private bool _isSpintingPressed;
        private Vector3 _currentInputMovement;

        public bool IsRunPressed => _isMovementPresesd;
        public bool IsJumpPressed => _isJumpPressed;
        public bool IsSpintPressed => _isSpintingPressed;
        public Vector3 CurrentInputMovement => _currentInputMovement;
        public InputPress(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.CharacterControl.Move.started += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.performed += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.canceled += OnHandleInputMovement;
            _playerInput.CharacterControl.Run.started += OnHandleInputRun;
            _playerInput.CharacterControl.Run.canceled += OnHandleInputRun;
            _playerInput.CharacterControl.Jump.started += OnHandleInputJump;
            _playerInput.CharacterControl.Jump.canceled += OnHandleInputJump;
        }

        public void EnableInput()
        {
            _playerInput.CharacterControl.Enable();

        }

        public void DisableInput()
        {
            _playerInput.CharacterControl.Disable();
        }




        #region On Read Input
        private void OnHandleInputMovement(InputAction.CallbackContext context)
        {
            Vector2 inputMovent = context.ReadValue<Vector2>();
            _currentInputMovement.x = inputMovent.x;
            _currentInputMovement.z = inputMovent.y;
            _isMovementPresesd = _currentInputMovement.x != 0 || _currentInputMovement.z != 0;
        }

        private void OnHandleInputRun(InputAction.CallbackContext context)
        {
            _isSpintingPressed = context.ReadValueAsButton();
        }

        private void OnHandleInputJump(InputAction.CallbackContext context)
        {
            _isJumpPressed = context.ReadValueAsButton();
        }
        #endregion
    }
}
