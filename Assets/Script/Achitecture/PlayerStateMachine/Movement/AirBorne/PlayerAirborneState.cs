
namespace Achitecture
{
    internal class PlayerAirborneState : PlayerBaseState
    {
        public PlayerAirborneState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _isRootState = false;
            _animtionHash = _context.AnimationHashs.IsAirborneHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.IsGrounded)
            {
                SwitchState(_factory.Grounded());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("AirBorne");
            InitializationSubState();
        }

        protected override void InitializationSubState()
        {
            if(_context.IsJumpPressed)
            {
                SetSubState(_factory.JumpRise());
            }
            else if(!_context.IsGrounded)
            {
                SetSubState(_factory.Fall());
            }
            _currentSubState?.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();

        }
    }
}
