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
            if(_context.PlayerPhysic.VelocityY <= 0/* && _context.Body.IsFall*/)
            {
                SwitchState(_factory.Fall());
            }
            //if (_context.PlayerPhysic.VelocityY <= 0 && !_context.Body.IsFall)
            //{
            //    SwitchState(_factory.JumpFall());
            //}
        }

        public override void EnterState()
        {
            base.EnterState();
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
            //_context.Body.IsJumping = true;
            _context.PlayerPhysic.VelocityY = _context.PlayerPhysic.InitialJumpVelocity;
            _context.PlayerPhysic.VelocityY = _context.PlayerPhysic.InitialJumpVelocity;
        }

        public override void ExitState()
        {
            //_context.Body.IsJumping = false;
            base.ExitState();
        }

        private void GravityEffect()
        {
            var oldYVelocity = _context.PlayerPhysic.VelocityY;
            var newVelocityY = _context.PlayerPhysic.VelocityY + _context.PlayerPhysic.Gravity * Time.deltaTime;
            _context.PlayerPhysic.VelocityY = (oldYVelocity + newVelocityY) * .5f;
        }
    }
}
