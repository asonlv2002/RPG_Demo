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
            if(_context.IsRunPressed && _context.IsSpintPressed)
            {
                SwitchState(_factory.Spint());
            }
            else if(!_context.IsRunPressed)
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
            _context._applyMovement.x = _context._currentMovement.x;
            _context._applyMovement.z = _context._currentMovement.z;
        }
    }
}
