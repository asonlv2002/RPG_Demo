using UnityEngine;
namespace Achitecture
{
    internal class PlayerJumpFallState : PlayerBaseState
    {
        public PlayerJumpFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsJumpFallHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.GroundPos.y <= (_context.HeightGroundBeginJump - _context.CharacterHeight/2))
            {
                SwitchState(_factory.Fall());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("JumpFall");
        }

        public override void UpdateState()
        {
            GravityEffect();
            base.UpdateState();
            CheckUpdateState();
        }

        private void GravityEffect()
        {
            float oldYVelocity = _context._currentMovement.y;
            _context._currentMovement.y = _context._currentMovement.y + _context.Gravity*2f * Time.deltaTime;
            _context._applyMovement.y = (oldYVelocity + _context._currentMovement.y) * .5f;
        }
    }
}
