
namespace Achitecture
{
    internal class PlayerAirborneState : PlayerBaseState, IRootState
    {
        public PlayerAirborneState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsAirborneHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.IsGrounded)
            {
                UnityEngine.Debug.Log(_childState);
                SwitchState(_factory.Grounded());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("AirBorne");
            InitializationSubState();
        }

        public void InitializationSubState()
        {
            if(_context.IsJumpPressed)
            {
                SetChildState(_factory.JumpRise());
            }
            else if(!_context.IsGrounded)
            {
                SetChildState(_factory.Fall());
            }
            _childState.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();

        }
    }
}
