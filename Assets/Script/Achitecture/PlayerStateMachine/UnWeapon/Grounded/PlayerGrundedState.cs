using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerGrundedState : PlayerBaseState,IRootState
    {
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if (stateControl.InputPress.IsJumpPressed && stateControl.MainContent.Body.FootTrack.IsOnGround || !stateControl.MainContent.Body.FootTrack.IsTerrestrial)
            {
                SwitchState(factoryState.Airborne());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Grounded");
            InitializationSubState();
        }
        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public void InitializationSubState()
        {
            if(stateControl.InputPress.IsRunPressed)
            {
                SetChildState(factoryState.Move());
            }else 
            {
                SetChildState(factoryState.StopOnGround());
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
            var constFeet = stateControl.MainContent.Physiscal.PhysiscVariable.ConstFeet;
            stateControl.MainContent.Physiscal.Y_VelocityApplie = stateControl.MainContent.Body.FootTrack.FLoatDirection* constFeet;
        }
    }
}
