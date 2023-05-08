using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture
{
    internal class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsIdleHash;
        }

        public override void CheckUpdateState()
        {
            if (_context.IsRunPressed)
            {
                SwitchState(_factory.Run());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("Idle");
            Idle();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

        private void Idle()
        {
            _context._applyMovement.x = 0;
            _context._applyMovement.z = 0;
        }
    }
}
