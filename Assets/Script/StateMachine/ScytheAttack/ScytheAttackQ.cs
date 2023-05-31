﻿namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackQ : ScytheAttack
    {
        float time;
        public ScytheAttackQ(StateCore stateContent) : base(stateContent)
        {
            ActionParameter = Animator.StringToHash("isAttackQ");
        }
        public override void EnterState()
        {
            base.EnterState();

            time = 2.067f;
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
            Debug.Log("ExitQ");
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();

            time -=Time.fixedDeltaTime;

        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputQ);
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputQ);
        }

        public override bool ConditionExitState() => time <= 0;
    }
}
