using UnityEngine;
namespace StateContents
{
    internal class PlayerFallState : MovementState
    {
        public PlayerFallState(StateCore stateContent, IMovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isFall");
        }
        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.GravityEffect(200f);
        }
        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return Physiscal.Y_VelocityApplie < 0f;
        }

        public override bool ConditionInitChildState()
        {
            return !Body.IsTerrestrial;
        }
    }
}
