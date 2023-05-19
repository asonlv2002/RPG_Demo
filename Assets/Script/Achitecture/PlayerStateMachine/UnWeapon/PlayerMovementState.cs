using UnityEngine;
namespace StateMachine
{
    internal class PlayerMovementState : PlayerBaseState, IRootState
    {
        public PlayerMovementState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) :
            base(playerStateMachine, playerStateFactory)
        {
        }

        public override void CheckUpdateState()
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            InitializationSubState();
        }

        public override void UpdateState()
        {

            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Movement();
        }

        public void InitializationSubState()
        {
            if (stateControl.MainContent.Body.FootTrack.IsTerrestrial)
            {
                SetChildState(factoryState.Grounded());
            }
            else
            {
                SetChildState(factoryState.Airborne());
            }
            childState.EnterState();
        }

        private void Movement()
        {
            stateControl.MainContent.Physiscal.MovementForceApplie();
        }
    }
}
