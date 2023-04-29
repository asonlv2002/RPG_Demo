using UnityEngine;
using UnityEngine.InputSystem;
namespace Achitecture
{
    internal class PlayerStateMachine : MonoBehaviour
    {
        PlayerInput _playerInput;
        private Vector2 _currentInputMovement;
        private Vector3 _currentMovement;
        private Vector3 _currentRunMovement;
        [SerializeField] float _rotationFactorFerFrame = 20f;
        bool _isMovementPresesd;
        bool _isSpintingPressed;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _chaController;
        [SerializeField] private float _forceMoverment;

        int isRunningHash;
        int isSpintingHash;
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.CharacterControl.Move.started += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.performed += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.canceled += OnHandleInputMovement;
            _playerInput.CharacterControl.Run.started += OnHandleInputRun;
            _playerInput.CharacterControl.Run.canceled += OnHandleInputRun;

            isRunningHash = Animator.StringToHash("Running");
            isSpintingHash = Animator.StringToHash("Spinting");

        }
        private void Update()
        {

            OnHandleMove();
            OnRotation();
            OnHandleAniamtion();
        }

        private void OnEnable()
        {
            _playerInput.CharacterControl.Enable();
        }

        private void OnDisable()
        {
            _playerInput.CharacterControl.Disable();
        }



        private void OnHandleMove()
        {
            if(_isSpintingPressed && _isMovementPresesd)
            {
                _chaController.Move(_currentRunMovement * Time.deltaTime);
            }
            else if(_isMovementPresesd)
            _chaController.Move(_currentMovement * Time.deltaTime);
        }

        private void OnRotation()
        {
            Vector3 postionToLookAt;

            postionToLookAt.x = _currentMovement.x;
            postionToLookAt.y = 0f;
            postionToLookAt.z = _currentMovement.z;

            Quaternion currentRotation = transform.rotation;

            if (_isMovementPresesd)
            {
                Quaternion targetRoation = Quaternion.LookRotation(postionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRoation, _rotationFactorFerFrame*Time.deltaTime);
            }
        }
        private void OnHandleAniamtion()
        {
            bool isRuning = _animator.GetBool(isRunningHash);
            bool isSpinting = _animator.GetBool(isSpintingHash);
            
            if(_isMovementPresesd && !isRuning)
            {
                _animator.SetBool(isRunningHash, true);
            }
            else if(!_isMovementPresesd && isRuning)
            {
                _animator.SetBool(isRunningHash, false);
            }
            else if((_isMovementPresesd && _isSpintingPressed) && !isSpinting)
            {
                _animator.SetBool(isSpintingHash, true);
            }
            else if((!_isMovementPresesd || !_isSpintingPressed) && isSpinting)
            {
                _animator.SetBool(isSpintingHash, false);
            }
            //if(_isMovementPresesd && !_isSpintingPressed)
            //{
            //    _animator.SetBool("Walk", true);
            //    _animator.SetBool("Run", false);
            //}
            //else if(_isSpintingPressed)
            //{
            //    _animator.SetBool("Run", true);
            //    _animator.SetBool("Walk", true);
            //}
            //else if(!_isSpintingPressed && !_isMovementPresesd)
            //{
            //    _animator.SetBool("Walk", false);
            //    _animator.SetBool("Run", false);
            //}
        }

        #region On Read Input
        private void OnHandleInputMovement(InputAction.CallbackContext context)
        {
            _currentInputMovement = context.ReadValue<Vector2>();
            _currentMovement.x = _currentInputMovement.x;
            _currentMovement.z = _currentInputMovement.y;
            _currentRunMovement = _currentMovement * 3f;
            _isMovementPresesd = _currentInputMovement.x != 0 || _currentInputMovement.y != 0;
        }

        private void OnHandleInputRun(InputAction.CallbackContext context)
        {
            _isSpintingPressed = context.ReadValueAsButton();
        }
        #endregion
    }
}
