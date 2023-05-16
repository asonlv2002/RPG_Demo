
using System.Collections.Generic;
namespace StateMachine
{
    internal class PlayerStateFactory
    {
        private PlayerStateMachine _context;
        private Dictionary<string, PlayerBaseState> _states;
        public PlayerStateFactory(PlayerStateMachine context)
        {
            _context = context;
            InitializationDictionaryStates();
        }

        private void InitializationDictionaryStates()
        {
            _states = new Dictionary<string, PlayerBaseState>();
            _states["Movement"] = new PlayerMovementState(_context, this);
            _states["Grounded"] = new PlayerGrundedState(_context, this);
            _states["Ariborne"] = new PlayerAirborneState(_context, this);

            _states["Move"] = new PlayerMoveState(_context, this);
            _states["Idle"] = new PlayerIdleState(_context, this);
            _states["Sprint"] = new PlayerSpintState(_context, this);

            _states["Run"] = new PlayerRunState(_context, this);
            _states["JumpRise"] = new PlayerJumpRiseState(_context, this);
            _states["JumpFall"] = new PlayerJumpFallState(_context, this);

            _states["Fall"] = new PlayerFallState(_context, this);

            _states["StopOnGround"] = new PlayerStopOnGroundState(_context, this);
            _states["SprintToIdle"] = new PlayerSprintToIdleState(_context, this);

        }

        public PlayerBaseState Movement() => _states["Movement"];
        public PlayerBaseState Grounded() => _states["Grounded"];
        public PlayerBaseState Idle() => _states["Idle"];

        public PlayerBaseState Move() => _states["Move"];
        public PlayerBaseState Run() => _states["Run"];
        public PlayerBaseState Sprint() => _states["Sprint"];
        public PlayerBaseState Airborne() => _states["Ariborne"];
        public PlayerBaseState JumpRise() => _states["JumpRise"];
        public PlayerBaseState JumpFall() => _states["JumpFall"];
        public PlayerBaseState Fall() => _states["Fall"];
        public PlayerBaseState SprintToIdle() => _states["SprintToIdle"];
        public PlayerBaseState StopOnGround() => _states["StopOnGround"];

    }
}
