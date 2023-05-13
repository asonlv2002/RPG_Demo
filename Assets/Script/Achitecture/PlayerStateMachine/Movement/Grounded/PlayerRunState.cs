using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture
{
    internal class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            _animtionHash = _context.AnimationHashs.IsRunHash;
        }

        public override void CheckUpdateState()
        {
            if(_context.InputPress.IsRunPressed && _context.InputPress.IsSpintPressed)
            {
                SwitchState(_factory.Spint());
            }
            else if(!_context.InputPress.IsRunPressed)
            {
                SwitchState(_factory.StopOnGround());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("Run");
        }

        public override void UpdateState()
        {

            base.UpdateState();
            CheckUpdateState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Run();
        }

        private void Run()
        {
            _context.PlayerPhysic.VelocityX = _context.InputPress.CurrentInputMovement.x * 2;
            _context.PlayerPhysic.VelocityZ = _context.InputPress.CurrentInputMovement.z * 2;

        }
    }
}
