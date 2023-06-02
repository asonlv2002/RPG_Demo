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
            TimeEnd = Time.time + 2f;
            IsExit = false;
            Debug.Log("EnterE");
            InputAttack.ReadInputToState();
            animator.applyRootMotion = true;
            animator.SetBool(ActionParameter, true);


        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(Time.time> TimeEnd && !IsExit)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackCompoA)) return;
            }
        }
        public override void ExitState()
        {
            Debug.Log("ExitE");
            animator.SetBool(ActionParameter, false);
            animator.applyRootMotion = true;
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

    }
}
