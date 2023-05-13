
namespace Achitecture.StateMachine
{
    internal class PlayerAirborneState : PlayerBaseState, IRootState
    {
        public PlayerAirborneState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsAirborneHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.Body.FootTrack.IsOnGround && _childState != _factory.JumpRise())
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

        public void InitializationSubState()
        {
            if(_context.InputPress.IsJumpPressed)
            {
                SetChildState(_factory.JumpRise());
            }
            else
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
