using UnityEngine;

namespace Achitecture
{
    internal class PlayerGrundedState : PlayerBaseState,IRootState
    {
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
            InitializationSubState();
        }
        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public void InitializationSubState()
        {
            if(_context.IsRunPressed)
            {
                SetChildState(_factory.Run());
            }else 
            {
                SetChildState(_factory.StopOnGround());
            }
            _childState.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            GravityEffect();
        }
        private void GravityEffect()
        {
            _context._currentMovement.y = _context.GroundedGravity;
            _context._applyMovement.y = _context.GroundedGravity;
        }

    }
}
