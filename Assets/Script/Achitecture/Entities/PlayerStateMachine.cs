using UnityEngine;
namespace StateMachine
{
    internal class PlayerStateMachine : Entities.BranchContent
    {
        private PlayerStateFactory _stateFactory;
        private PlayerBaseState _currentState;
        private PlayerBaseState _lastState;
        public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public PlayerBaseState LastState { get => _lastState; set { _lastState = value; } }

        public override void InitMainContent(Entities.PlayerRootContent mainContent)
        {
            base.InitMainContent(mainContent);
            SetStartState();
        }
        private void Awake()
        {

        }
        private void Update()
        {
            _currentState.UpdateState();

        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdateState();
        }

        private void SetStartState()
        {
            _stateFactory = new PlayerStateFactory(this);
            _currentState = _stateFactory.Movement();
            _currentState.EnterState();
        }

    }
}
