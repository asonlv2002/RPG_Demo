using UnityEngine;

namespace Achitecture
{
    internal class PlayerGrundedState : PlayerBaseState
    {
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            _isRootState = false;
            _animtionHash = _context.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.IsJumpPressed || !_context.IsGrounded)
            {
                SwitchState(_factory.Airborne());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Grounded");
            InitializationSubState();
        }
        public override void UpdateState()
        {
            GravityEffect();
            base.UpdateState();
            CheckUpdateState();
        }
        protected override void InitializationSubState()
        {
            if(_context.IsRunPressed)
            {
                SetSubState(_factory.Run());
            }else 
            {
                SetSubState(_factory.Idle());
            }
            _currentSubState.EnterState();
        }

        private void GravityEffect()
        {
            _context._currentMovement.y = _context.GroundedGravity;
            _context._applyMovement.y = _context.GroundedGravity;
        }
    }
}
