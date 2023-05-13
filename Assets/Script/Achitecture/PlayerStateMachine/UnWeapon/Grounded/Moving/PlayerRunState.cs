
namespace Achitecture.StateMachine
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
                SwitchState(_factory.Sprint());
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
            _context.PlayerPhysic.VelocityX = _context._cameraRelativeMovement.normalized.x * 2;
            _context.PlayerPhysic.VelocityZ = _context._cameraRelativeMovement.normalized.z * 2;
        }
    }
}
