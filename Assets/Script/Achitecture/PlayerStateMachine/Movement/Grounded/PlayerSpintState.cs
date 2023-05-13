using UnityEngine;

namespace Achitecture
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
            Debug.Log("Spint");
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
            _context.PlayerPhysic.VelocityX = _context.InputPress.CurrentInputMovement.x*4;
            _context.PlayerPhysic.VelocityZ = _context.InputPress.CurrentInputMovement.z*4;
        }
    }
}
