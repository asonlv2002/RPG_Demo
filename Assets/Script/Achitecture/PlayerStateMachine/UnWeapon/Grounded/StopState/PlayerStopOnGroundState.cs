namespace StateMachine
{
    internal class PlayerStopOnGroundState : PlayerBaseState, IRootState
    {
        private PlayerBaseState _lastState;
        public PlayerStopOnGroundState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsStopOnGround;
        }

        public override void EnterState()
        {
            _lastState = stateControl.CurrentState;
            base.EnterState();
            InitializationSubState();

            StopOnGround();
        }

        public override void CheckUpdateState()
        {
            if (stateControl.MainContent.InputAction.InputPress.IsRunPressed)
            {
                SwitchState(factoryState.Move());
            }
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();
        }

        public void InitializationSubState()
        {
            if(_lastState == factoryState.Sprint())
            {
                SetChildState(factoryState.SprintToIdle());
            }
            else
            {
                SetChildState(factoryState.Idle());
            }
            stateControl.LastState = null;
            childState.EnterState();
        }

        private void StopOnGround()
        {
            stateControl.MainContent.Physiscal.VelocityApplie = UnityEngine.Vector3.up * stateControl.MainContent.Physiscal.Y_VelocityApplie;
        }
    }
}
