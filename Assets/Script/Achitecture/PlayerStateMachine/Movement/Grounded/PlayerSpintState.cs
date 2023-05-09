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
            if(!_context.IsSpintPressed)
            {
                SwitchState(_factory.Run());
            }
            else if(!_context.IsRunPressed)
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
            _context._applyMovement.x = _context._currentRunMovement.x;
            _context._applyMovement.z = _context._currentRunMovement.z;
        }
    }
}
