using UnityEngine;
namespace StateMachine
{
    internal class PlayerFallState : PlayerBaseState
    {
        public PlayerFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsFallHash;
        }

        public override void CheckUpdateState()
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();
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
            float gravity = stateControl.MainContent.Physiscal.PhysiscVariable.Gravity;
            float oldYVelocity = stateControl.MainContent.Physiscal.Y_VelocityApplie;
            float newYVelocity = stateControl.MainContent.Physiscal.Y_VelocityApplie + gravity * 2f * Time.fixedDeltaTime;
            stateControl.MainContent.Physiscal.Y_VelocityApplie = (oldYVelocity + newYVelocity) / 2f;
        }
    }
}
