using UnityEngine;
namespace StateContents
{
    internal class PlayerSprintToIdleState : MovementState
    {
        public PlayerSprintToIdleState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
        }

        public float TimeExitState { get; private set; }


        public override void EnterState()
        {
            base.EnterState();
            TimeExitState = 0.6333333333333333f;
        }


        public override void UpdateState()
        {
            CalculatorTimeExit();
            base.UpdateState();
        }

        public void CalculatorTimeExit()
        {
            TimeExitState -= UnityEngine.Time.deltaTime;
        }

        public override bool ConditionEnterState()
        {
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}