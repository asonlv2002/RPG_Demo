namespace StateMachine
{
    internal class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsIdleHash;
        }

        public override void CheckUpdateState()
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

    }
}
