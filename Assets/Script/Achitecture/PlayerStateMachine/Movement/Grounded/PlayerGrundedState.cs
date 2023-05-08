using UnityEngine;

namespace Achitecture
{
    internal class PlayerGrundedState : PlayerBaseState
    {
        float _timeExitGrounded;
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if (_context.IsJumpPressed || !_context.IsGrounded)
            {
                SwitchState(_factory.Airborne());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Grounded");
            InitialaztionSubState();
        }
        public override void UpdateState()
        {
            GravityEffect();
            base.UpdateState();
            CheckUpdateState();
        }
        public void InitialaztionSubState()
        {
            if(_context.IsRunPressed)
            {
                SetChildState(_factory.Run());
            }else 
            {
                SetChildState(_factory.Idle());
            }
            _childState.EnterState();
        }

        private void GravityEffect()
        {
            _context._currentMovement.y = _context.GroundedGravity;
            _context._applyMovement.y = _context.GroundedGravity;
        }

    }
}
