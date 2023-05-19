using UnityEngine;
namespace StateMachine
{
    internal class PlayerSprintToIdleState : PlayerBaseState, IConversionState
    {
        public float TimeExitState { get; private set; }
        public PlayerSprintToIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            animtionHash = stateControl.MainContent.Animator.AnimationIntHashs.IsSprintToStop;
        }

        public override void EnterState()
        {
            base.EnterState();
            TimeExitState = 0.6333333333333333f;
        }


        public override void CheckUpdateState()
        {
            if(TimeExitState <= 0)
            {
                SwitchState(factoryState.Idle());
            }
        }

        public override void UpdateState()
        {
            CalculatorTimeExit();
            base.UpdateState();
            CheckUpdateState();
        }

        public void CalculatorTimeExit()
        {
            TimeExitState -= UnityEngine.Time.deltaTime;
        }
    }
}