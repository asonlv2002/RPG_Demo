namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackE : ScytheAttack
    {
        float TimeEnd;
        public ScytheAttackE(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isAttackE");
        }
        public override void EnterState()
        {
            base.EnterState();
            InputAttack.ReadInputToState();
            animator.SetBool(ActionParameter, true);
            TimeEnd = Time.time + 2f;

        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
        public override void ExitState()
        {
            Debug.Log("ExitE");
            animator.SetBool(ActionParameter, false);
            base.ExitState();

        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE);
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE);
        }

        public override bool ConditionExitState()
        {
            return Time.time >= TimeEnd;
        }
    }
}
