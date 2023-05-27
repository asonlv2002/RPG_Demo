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


        public override void SwitchToOtherRoot()
        {
            if(TimeExitState <= 0)
            {
                SwitchState(StateContain.Idle);
            }
        }

        public override void UpdateState()
        {
            CalculatorTimeExit();
            base.UpdateState();
            SwitchToOtherRoot();
        }

        public void CalculatorTimeExit()
        {
            TimeExitState -= UnityEngine.Time.deltaTime;
        }
    }
}