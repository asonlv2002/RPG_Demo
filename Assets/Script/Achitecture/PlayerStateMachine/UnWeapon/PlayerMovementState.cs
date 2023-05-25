using UnityEngine;
namespace StateMachine
{
    internal class PlayerMovementState : TransformState, IRootState
    {
        public PlayerMovementState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = 0;
        }

        public override void SwitchToOtherRoot()
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            InitilationChildrenState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Movement();
        }

        public void InitilationChildrenState()
        {
            if (Body.IsTerrestrial)
            {
                SetChildState(StateContain.Grounded);
            }
            else
            {
                SetChildState(StateContain.Airborne);
            }
            childState.EnterState();
        }

        private void Movement()
        {
            Physiscal.MovementForceApplie();
        }
    }
}
