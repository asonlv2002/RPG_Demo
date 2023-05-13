using UnityEngine;

namespace Achitecture.StateMachine
{
    internal class PlayerSpintState : PlayerBaseState
    {
        public PlayerSpintState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsSprintHash;
        }

        public override void CheckUpdateState()
        {
            if(!_context.InputPress.IsSpintPressed)
            {
                SwitchState(_factory.Run());
            }
            else if(!_context.InputPress.IsRunPressed)
            {
                SwitchState(_factory.StopOnGround());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Sprint");
        }

        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Sprint();
        }

        private void Sprint()
        {
            _context.PlayerPhysic.VelocityX = _context._cameraRelativeMovement.normalized.x * 4;
            _context.PlayerPhysic.VelocityZ = _context._cameraRelativeMovement.normalized.z * 4;
        }
    }
}
