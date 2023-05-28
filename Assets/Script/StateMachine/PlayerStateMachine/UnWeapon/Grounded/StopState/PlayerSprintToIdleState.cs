using UnityEngine;
namespace StateMachine
{
    internal class PlayerSprintToIdleState : TransformState, IConversionState
    {
        public PlayerSprintToIdleState(IStateContext stateContext, ITransformStateStore stateTransition) : base(stateContext, stateTransition)
        {
            animtionID = AnimationID.IsSprintToStop;
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