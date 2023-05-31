namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackE : ScytheAttack
    {
        float time;
        public ScytheAttackE(StateCore stateContent) : base(stateContent)
        {
            ActionParameter = Animator.StringToHash("isAttackE");
        }
        public override void EnterState()
        {
            base.EnterState();
            time = 2f;
            animator.SetBool(ActionParameter, true);

        }
        public override void UpdateState()
        {
            if (time < 0)
            {
                InputAttack.ReadInputToState();
                time = 0;
            }
            base.UpdateState();

        }
        public override void ExitState()
        {
            Debug.Log("ExitE");
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();

            time -= Time.fixedDeltaTime;

        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE);
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE);
        }

        public override bool ConditionExitState() => time <= 0;
    }
}
