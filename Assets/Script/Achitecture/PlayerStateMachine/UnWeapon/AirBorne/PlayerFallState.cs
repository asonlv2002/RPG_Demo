using UnityEngine;
namespace Achitecture.StateMachine
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

            base.UpdateState();
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
