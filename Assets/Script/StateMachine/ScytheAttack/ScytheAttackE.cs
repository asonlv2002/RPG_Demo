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
            base.ExitState();

        }

        public override bool ConditionEnterState()
        {
            return ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputQ) && Body.IsOnGround;
        }

    }
}
