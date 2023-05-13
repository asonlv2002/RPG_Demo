using UnityEngine;
using EntitiesContents;
namespace Achitecture.StateMachine
{
    internal class PlayerStateMachine : BranchContent
    {
        public Vector3 _cameraRelativeMovement;

        private AnimationHashContain _animationHashContain;
        [SerializeField] Animator _animator;
        
        public Animator AnimationControl => _animator;
        public AnimationHashContain AnimationHashs => _animationHashContain;
        private void Awake()
        {
            InputPress = new InputPressed(new PlayerInput());
;           _animationHashContain = new AnimationHashContain();
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

        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdateState();

        }

        public Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

            var cameraForwradZProduc = vectorToRotate.z * cameraForward;
            var cameraRightXProduct = vectorToRotate.x * cameraRight;

            Vector3 result = cameraForwradZProduc + cameraRightXProduct;

            result.y = vectorToRotate.y;

            return result;
        }

        private void OnEnable()
        {
            InputPress.EnableInput();
        }

        private void OnDisable()
        {
            InputPress.DisableInput();
        }

        #region PlayerStateMachine's Context

        private PlayerStateFactory _stateFactory;
        public PlayerStateFactory StateFactory => _stateFactory;

        private PlayerBaseState _currentState;
        private PlayerBaseState _lastState;
        public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public PlayerBaseState LastState { get => _lastState; set { _lastState = value; } }
        [field : SerializeField] public InputPressed InputPress { get; private set; }
        #endregion

    }
}
