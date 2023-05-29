using UnityEngine;
namespace StateContent
{
    internal class PlayerMovementState : MovementState
    {
        public PlayerMovementState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            AnimatorParameter = 0;
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Movement();
        }
        private void Movement()
        {
            Physiscal.MovementForceApplie();
        }

        public override bool ConditionEnterState()
        {
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
