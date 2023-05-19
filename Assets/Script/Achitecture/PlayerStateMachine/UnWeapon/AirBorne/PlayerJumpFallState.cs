using UnityEngine;
namespace StateMachine
{
    internal class PlayerJumpFallState : PlayerBaseState
    {
        public PlayerJumpFallState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsJumpFallHash;
        }

        public override void CheckUpdateState()
        {
            //if(stateControl.GroundPos.y <= -5 /*(stateControl.HeightGroundBeginJump - stateControl.CharacterHeight/2)*/)
            //{
            //    SwitchState(factoryState.Fall());
            //}
        }

        public override void EnterState()
        {
            base.EnterState();
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
            float gravity = stateControl.MainContent.Physiscal.PhysiscVariable.Gravity;
            float oldYVelocity = stateControl.MainContent.Physiscal.Y_VelocityApplie;
            float newYVelocity = stateControl.MainContent.Physiscal.Y_VelocityApplie + gravity * 2f * Time.fixedDeltaTime;
            stateControl.MainContent.Physiscal.Y_VelocityApplie = (oldYVelocity + newYVelocity) / 2f;
        }
    }
}
