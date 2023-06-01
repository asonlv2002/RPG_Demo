namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackQ : ScytheAttack
    {
        float TimeEnd;
        public ScytheAttackQ(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent,Store)
        {
            ActionParameter = Animator.StringToHash("isAttackQ");
        }
        public override void EnterState()
        {
            base.EnterState();
            TimeEnd = Time.time + 2.067f;
            InputAttack.ReadInputToState();
            animator.SetBool(ActionParameter, true);
        }
        public override void UpdateState()
        {
            if (ConditionExitState() && ConditionEnterState())
            {
                EnterState();
            }
            else base.UpdateState();
        }
        public override void ExitState()
        {
            Debug.Log("ExitQ");
            animator.SetBool(ActionParameter, false);
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputQ) && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputQ) && Body.IsOnGround;
        }

        public override bool ConditionExitState()
        {
            return Time.time > TimeEnd;
        }
    }
}
