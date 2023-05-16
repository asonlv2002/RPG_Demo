using UnityEngine;

namespace StateMachine
{
    internal class PlayerJumpRiseState : PlayerBaseState
    {
        public PlayerJumpRiseState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsJumpRiseHash;
        }

        public override void CheckUpdateState()
        {
            if(stateControl.MainContent.Physiscal.GetCurrentPlayerVerticalVelocity().y <= 0/* && stateControl.Body.IsFall*/)
            {
                SwitchState(factoryState.Fall());
            }
            //if (stateControl.Physiscal.Y_VelocityApplie <= 0 && !stateControl.Body.IsFall)
            //{
            //    SwitchState(factoryState.JumpFall());
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
            base.UpdateState();
            CheckUpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            GravityEffect();
        }

        private void Jump()
        {
            stateControl.MainContent.Physiscal.Y_VelocityApplie = stateControl.MainContent.Physiscal.PhysiscVariable.JumpHeight;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        private void GravityEffect()
        {
            var gravity = stateControl.MainContent.Physiscal.PhysiscVariable.Gravity;
            var oldYVelocity = stateControl.MainContent.Physiscal.Y_VelocityApplie;
            var newVelocityY = stateControl.MainContent.Physiscal.Y_VelocityApplie + gravity * Time.deltaTime;
            stateControl.MainContent.Physiscal.Y_VelocityApplie = (oldYVelocity + newVelocityY) * .5f;
        }
    }
}
