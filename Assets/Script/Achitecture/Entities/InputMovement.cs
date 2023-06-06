
using UnityEngine;
using UnityEngine.InputSystem;
namespace InputContents
{
    [System.Serializable]
    internal class InputMovement : InputComponent
    {
        private PlayerInput _playerInput;
        private bool _isRunPresesd;
        private Vector3 _currentInputMovement;
        private bool _isSprintPresesd;
        private bool _isJumpPresesd;

        public bool IsRunPressed => _isRunPresesd;
        public bool IsJumpPressed => _isJumpPresesd = _playerInput.PlayerMovement.Jump.IsPressed();
        public bool IsSpintPressed => _isSprintPresesd = _playerInput.PlayerMovement.Sprint.IsPressed();
        public Vector3 CurrentInputMovement => _currentInputMovement;
        public bool IsEquipPressed => _playerInput.PlayerMovement.EquipAction.IsPressed();

        public float DirectionMovement => _currentInputMovement.z;
        public float DirectionRotation => _currentInputMovement.x;
        public InputMovement(PlayerInput inputActions)
        {
            _playerInput = inputActions;
            _playerInput.PlayerMovement.Enable();
            _playerInput.PlayerMovement.Run.started += OnHandleInputMovement;
            _playerInput.PlayerMovement.Run.performed += OnHandleInputMovement;
            _playerInput.PlayerMovement.Run.canceled += OnHandleInputMovement;
        }

        #region On Read Input
        private void OnHandleInputMovement(InputAction.CallbackContext context)
        {
            Vector2 inputMovent = context.ReadValue<Vector2>();

            if (inputMovent.x > 0) _currentInputMovement.x = 1;
            else if (inputMovent.x < 0) _currentInputMovement.x = -1;
            else if (inputMovent.x == 0) _currentInputMovement.x = 0;
            _currentInputMovement.z = inputMovent.y;
            _isRunPresesd = _currentInputMovement.x != 0 || _currentInputMovement.z != 0;
        }
        #endregion
    }
}
