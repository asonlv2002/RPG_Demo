using UnityEngine;
using UnityEngine.InputSystem;
namespace Achitecture
{
    internal class PlayerStateMachine : MonoBehaviour
    {
        PlayerInput _playerInput;
        private Vector2 _currentInputMovement;
        public Vector3 _currentMovement;
        public Vector3 _currentRunMovement;
        public Vector3 _applyMovement;
        //[SerializeField] float _rotationFactorFerFrame = 20f;
        bool _isMovementPresesd;
        bool _isSpintingPressed = false;

        private AnimationHashContain _animationHashContain;
        [SerializeField] Animator _animator;
        [SerializeField] private CharacterController _chaController;
        [SerializeField] private float _forceMoverment;
        [SerializeField] Transform _groundPosition;
        [SerializeField] PlayerPhysics _playerPhysics;


        private float _gravity = -9.8f;
        private float _groundedGravity = -0.05f;
        private bool _isJumpPressed = false;
        private float _heightGroundBeginJump;
        private float _maxTimeJump = 0.75f;
        private float _maxJumpHeight = 2f;
        private float _initialJumpVelocity;

        public float Gravity { get => _gravity; set => _gravity = value; }
        public float GroundedGravity { get => _groundedGravity; set => _groundedGravity = value; }
        public float MaxTimeJump => _maxTimeJump;
        public float MaxJumpHeight => _maxJumpHeight;
        public float InitialJumpVelocity { get => _initialJumpVelocity; set => _initialJumpVelocity = value; }
        public float HeightGroundBeginJump { get => _heightGroundBeginJump; set => _heightGroundBeginJump = value; }
        public Vector3 GroundPos => _groundPosition.position;
        public float CharacterHeight => _playerPhysics.Body.height;
        public bool IsRunPressed => _isMovementPresesd;
        public bool IsJumpPressed => _isJumpPressed;
        public bool IsGrounded => _playerPhysics.IsGrounded;
        public bool IsSpintPressed => _isSpintingPressed;

        public Animator AnimationControl => _animator;
        public AnimationHashContain AnimationHashs => _animationHashContain;
        public PlayerPhysics PlayerPhysic => _playerPhysics;
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.CharacterControl.Move.started += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.performed += OnHandleInputMovement;
            _playerInput.CharacterControl.Move.canceled += OnHandleInputMovement;
            _playerInput.CharacterControl.Run.started += OnHandleInputRun;
            _playerInput.CharacterControl.Run.canceled += OnHandleInputRun;
            _playerInput.CharacterControl.Jump.started += OnHandleInputJump;
            _playerInput.CharacterControl.Jump.canceled += OnHandleInputJump;

            _animationHashContain = new AnimationHashContain();
        }

        private void Start()
        {
            _stateFactory = new PlayerStateFactory(this);
            _currentState = _stateFactory.Movement();
            _currentState.EnterState();
        }


        private void Update()
        {
            _currentState.UpdateState();
            Debug.Log(_currentState.ToString());
            //_chaController.Move(_applyMovement*Time.deltaTime);
            _playerPhysics.Physics.velocity = _applyMovement * Time.deltaTime;

        }

        //private void FixedUpdate()
        //{
        //    _playerPhysics.Physics.velocity = _applyMovement * Time.deltaTime;
        //}




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

        private void OnHandleInputJump(InputAction.CallbackContext context)
        {
            _isJumpPressed = context.ReadValueAsButton();
        }
        #endregion


        private void OnEnable()
        {
            _playerInput.CharacterControl.Enable();
        }

        private void OnDisable()
        {
            _playerInput.CharacterControl.Disable();
        }

        #region PlayerStateMachine's Context

        private PlayerStateFactory _stateFactory;
        public PlayerStateFactory StateFactory => _stateFactory;

        private PlayerBaseState _currentState;
        public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

        #endregion

    }
}
