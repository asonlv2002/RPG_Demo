using UnityEngine;

namespace Achitecture
{
    internal class PlayerJumpRiseState : PlayerBaseState
    {
        public PlayerJumpRiseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsJumpRiseHash;
        }

        public override void CheckUpdateState()
        {
            if(_context._applyMovement.y < 0)
            {
                SwitchState(_factory.JumpFall());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            GetPositionBeginJump();
            Jump();
            Debug.Log("JumpRise");
        }

        public override void UpdateState()
        {

            GravityEffect();
            base.UpdateState();
            CheckUpdateState();
        }

        private void Jump()
        {
            _context.IsJumping = true;
            _context._currentMovement.y = _context.InitialJumpVelocity;
            _context._applyMovement.y = _context.InitialJumpVelocity;
        }

        public override void ExitState()
        {
            _context.IsJumping = false;
            base.ExitState();
        }

        private void GravityEffect()
        {
            float oldYVelocity = _context._currentMovement.y;
            _context._currentMovement.y = _context._currentMovement.y + _context.Gravity * Time.deltaTime;
            _context._applyMovement.y = (oldYVelocity + _context._currentMovement.y) * .5f;
        }

        private void GetPositionBeginJump()
        {
            _context.HeightGroundBeginJump = _context.GroundPos.y;
        }
    }
}
