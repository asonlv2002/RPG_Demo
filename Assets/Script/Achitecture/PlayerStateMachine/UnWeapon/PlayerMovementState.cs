using UnityEngine;
namespace Achitecture.StateMachine
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
            UnityEngine.Debug.Log("Movement");
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
            if (_context.Body.FootTrack.IsTerrestrial)
            {
                SetChildState(_factory.Grounded());
            }
            else
            {
                SetChildState(_factory.Airborne());
            }
            _childState.EnterState();
            //SetChildState(_factory.Grounded());
            //_childState.EnterState();
        }



        private void Movement()
        {
            
            _context.PlayerPhysic.MovementForceApplie();
        }
    }
}
