using UnityEngine;
namespace Achitecture
{
    internal class PlayerSprintToIdleState : PlayerBaseState, IConversionState
    {
        public float TimeExitState { get; private set; }
        public PlayerSprintToIdleState(PlayerStateMachine playerStateMachine, PlayerStateFactory playerStateFactory) : base(playerStateMachine, playerStateFactory)
        {
            TimeExitState = 0.25f;
        }

        public override void EnterState()
        {
            Debug.Log("SprintToIdle");
            base.EnterState();
            TimeExitState = 0.25f;
        }


        public override void CheckUpdateState()
        {
            if(TimeExitState <= 0)
            {
                SwitchState(_factory.Idle());
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