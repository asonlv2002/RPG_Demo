using UnityEngine;

namespace StateMachine
{
    internal class PlayerSpintState : TransformState
    {
        public PlayerSpintState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsSprintHash;
        }

        public override void SwitchToOtherRoot()
        {
            if(!Input.IsSpintPressed)
            {
                SwitchState(StateContain.Run);
            }
            else if(!Input.IsRunPressed)
            {
                SwitchState(StateContain.StopOnGround);
            }
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToOtherRoot();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Sprint();
        }

        private void Sprint()
        {
            float sprintSpeed = 2f;
            Physiscal.X_VelocityApplie = Input.CurrentInputMovement.x * sprintSpeed;
            Physiscal.Z_VelocityApplie = Input.CurrentInputMovement.z * sprintSpeed;
        }
    }
}
