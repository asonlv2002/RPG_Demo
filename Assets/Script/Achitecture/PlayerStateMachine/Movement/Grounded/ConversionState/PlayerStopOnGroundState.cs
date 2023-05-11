namespace Achitecture
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
            if (_context.IsRunPressed)
            {
                SwitchState(_factory.Run());
            }
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

        public void InitializationSubState()
        {
            if(_lastState == _factory.Spint())
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
            _context._applyMovement.x = 0;
            _context._applyMovement.z = 0;
        }
    }
}
