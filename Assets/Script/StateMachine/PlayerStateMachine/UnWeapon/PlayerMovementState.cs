using UnityEngine;
namespace StateMachine
{
    internal class PlayerMovementState : TransformState
    {
        public PlayerMovementState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = 0;
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Movement();
        }

        //  void InitilationChildrenState()
        // {
        //     if (StateContain.Grounded.ConditionInitChildState()) SetChildState(StateContain.Grounded);
        //     else SetChildState(StateContain.Airborne);
        //     currentChildState.EnterState();
        // }

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
