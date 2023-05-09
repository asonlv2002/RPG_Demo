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
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("Idle");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

    }
}
