
namespace StateMachine
{
    internal class PlayerAirborneState : PlayerBaseState, IRootState
    {
        public PlayerAirborneState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsAirborneHash;
        }

        public override void CheckUpdateState()
        {
            if(stateControl.MainContent.Body.FootTrack.IsOnGround && childState != factoryState.JumpRise())
            {
                SwitchState(factoryState.Grounded());
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            UnityEngine.Debug.Log("AirBorne");
            InitializationSubState();
        }

        public void InitializationSubState()
        {
            if(stateControl.MainContent.InputAction.InputPress.IsJumpPressed)
            {
                SetChildState(factoryState.JumpRise());
            }
            else
            {
                SetChildState(factoryState.Fall());
            }
            childState.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            CheckUpdateState();

        }
    }
}
