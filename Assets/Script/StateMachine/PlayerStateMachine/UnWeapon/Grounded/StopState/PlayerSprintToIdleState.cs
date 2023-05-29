using UnityEngine;
namespace StateContent
{
    internal class PlayerSprintToIdleState : MovementState
    {
        public PlayerSprintToIdleState(IStateContent stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
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
            SwitchToFriendState();
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