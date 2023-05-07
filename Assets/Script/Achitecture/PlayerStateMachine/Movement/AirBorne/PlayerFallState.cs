using UnityEngine;
namespace Achitecture
{
    internal class PlayerFallState : PlayerBaseState
    {
        public PlayerFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsFallHash;
        }

        public override void CheckUpdateState()
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Fall");
        }

        public override void UpdateState()
        {
            GravityEffect();
            base.UpdateState();
        }

        private void GravityEffect()
        {
            float oldYVelocity = _context._currentMovement.y;
            _context._currentMovement.y = _context._currentMovement.y + _context.Gravity * 2f * Time.deltaTime;
            _context._applyMovement.y = (oldYVelocity + _context._currentMovement.y) * .5f;
        }
    }
}
