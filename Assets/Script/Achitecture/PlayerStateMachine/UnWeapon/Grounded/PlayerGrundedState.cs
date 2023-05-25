using UnityEngine;

namespace StateMachine
{
    internal class PlayerGroundedState : TransformState,IRootState
    {
        public PlayerGroundedState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsGroundHash;
        }

        public override void SwitchToOtherRoot()
        {
            if (Input.IsJumpPressed && Body.IsOnGround || !Body.IsTerrestrial)
            {
                SwitchState(StateContain.Airborne);
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            InitilationChildrenState();
        }
        public override void UpdateState()
        {

            base.UpdateState();
            SwitchToOtherRoot();
        }
        public void InitilationChildrenState()
        {
            if(Input.IsRunPressed)
            {
                SetChildState(StateContain.Move);
            }else 
            {
                SetChildState(StateContain.StopOnGround);
            }
            childState.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            FloatBodyOnGround();
        }

        private void FloatBodyOnGround()
        {
            var constFeet = Physiscal.ConstFeet;
            Physiscal.Y_VelocityApplie = Body.FLoatDirection* constFeet;
        }
    }
}