using UnityEngine;

namespace StateContent
{
    internal class PlayerSpintState : MovementState
    {
        public PlayerSpintState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = MovementParameter.IsSprintHash;
        }

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
            Physiscal.X_VelocityApplie = InputMovement.CurrentInputMovement.x * sprintSpeed;
            Physiscal.Z_VelocityApplie = InputMovement.CurrentInputMovement.z * sprintSpeed;
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsSpintPressed;
        }
    }
}
