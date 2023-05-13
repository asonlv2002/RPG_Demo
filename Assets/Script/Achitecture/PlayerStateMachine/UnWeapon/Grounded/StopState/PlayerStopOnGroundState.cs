namespace Achitecture.StateMachine
{
    internal class PlayerStopOnGroundState : PlayerBaseState, IRootState
    {
        private PlayerBaseState _lastState;
        public PlayerStopOnGroundState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsStopOnGround;
        }

        public override void EnterState()
        {
            _lastState = _context.CurrentState;
            base.EnterState();
            UnityEngine.Debug.Log("StopOnGround");
            InitializationSubState();

            StopOnGround();
        }

        public override void CheckUpdateState()
        {
            if (_context.InputPress.IsRunPressed)
            {
                SwitchState(_factory.Move());
            }
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

        public void InitializationSubState()
        {
            if(_lastState == _factory.Sprint())
            {
                SetChildState(_factory.SprintToIdle());
            }
            else
            {
                SetChildState(_factory.Idle());
            }
            _context.LastState = null;
            _childState.EnterState();
        }

        private void StopOnGround()
        {
            _context.PlayerPhysic.VelocityApplie = UnityEngine.Vector3.up * _context.PlayerPhysic.VelocityY;
        }
    }
}
