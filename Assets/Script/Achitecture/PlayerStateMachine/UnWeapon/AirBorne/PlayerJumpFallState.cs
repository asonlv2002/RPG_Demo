using UnityEngine;
namespace Achitecture.StateMachine
{
    internal class PlayerJumpFallState : PlayerBaseState
    {
        public PlayerJumpFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsJumpFallHash;
        }

        public override void CheckUpdateState()
        {
            //if(_context.GroundPos.y <= -5 /*(_context.HeightGroundBeginJump - _context.CharacterHeight/2)*/)
            //{
            //    SwitchState(_factory.Fall());
            //}
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("JumpFall");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            GravityEffect();

        }
        private void GravityEffect()
        {
            float oldYVelocity = _context.PlayerPhysic.VelocityY;
            float newYVelocity = _context.PlayerPhysic.VelocityY + _context.PlayerPhysic.Gravity * 2f * Time.fixedDeltaTime;
            _context.PlayerPhysic.VelocityY = (oldYVelocity + newYVelocity) / 2f;
        }
    }
}
