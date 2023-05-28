using UnityEngine;

namespace StateMachine
{
    internal class PlayerSpintState : TransformState
    {
        public PlayerSpintState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsSprintHash;
        }

        //public override void SwitchToFriendState()
        //{
        //    if(StateContain.Run.ConditionEnterState()) SwitchState(StateContain.Run);
        //}

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToFriendState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Sprint();
        }

        private void Sprint()
        {
            float sprintSpeed = 2f;
            Physiscal.X_VelocityApplie = InputTransform.CurrentInputMovement.x * sprintSpeed;
            Physiscal.Z_VelocityApplie = InputTransform.CurrentInputMovement.z * sprintSpeed;
        }

        public override bool ConditionEnterState()
        {
            return InputTransform.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputTransform.IsSpintPressed;
        }
    }
}
