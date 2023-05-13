using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerGrundedState : PlayerBaseState,IRootState
    {
        public PlayerGrundedState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) 
            : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsGroundHash;
        }

        public override void CheckUpdateState()
        {
            if (_context.InputPress.IsJumpPressed && _context.Body.FootTrack.IsOnGround || !_context.Body.FootTrack.IsTerrestrial)
            {
                SwitchState(_factory.Airborne());
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
            if(_context.InputPress.IsRunPressed)
            {
                SetChildState(_factory.Move());
            }else 
            {
                SetChildState(_factory.StopOnGround());
            }
            _childState.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            FloatBodyOnGround();
        }

        private void FloatBodyOnGround()
        {

            _context.PlayerPhysic.VelocityY = _context.Body.FootTrack.FLoatDirection* 5f;
        }
    }
}
