using UnityEngine;

namespace StateMachine
{
    internal class PlayerJumpRiseState : TransformState
    {
        public PlayerJumpRiseState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsJumpRiseHash;
        }

        public override void SwitchToOtherRoot()
        {
            if(Physiscal.CurrenRigibodyVelocity.y <= 0/* && stateControl.Body.IsFall*/)
            {
                SwitchState(StateContain.Fall);
            }
            //if (stateControl.PhysiscalProvider.Y_VelocityApplie <= 0 && !stateControl.Body.IsFall)
            //{
            //    SwitchState(StateContain.JumpFall());
            //}
        }

        public override void EnterState()
        {
            base.EnterState();
            Jump();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            SwitchToOtherRoot();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            GravityEffect();
        }

        private void Jump()
        {
            Physiscal.Y_VelocityApplie = Physiscal.JumpHeight;
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        private void GravityEffect()
        {
            var gravity = Physiscal.Gravity;
            var oldYVelocity = Physiscal.Y_VelocityApplie;
            var newVelocityY = Physiscal.Y_VelocityApplie + gravity * Time.deltaTime;
            Physiscal.Y_VelocityApplie = (oldYVelocity + newVelocityY) * .5f;
        }
    } 
}
