namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class AttackAC : ScytheAttack
    {
        public AttackAC(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isAC");
        }

        public override void EnterState()
        {
            animator.SetBool(ActionParameter, true);
            IsExit = false;
            base.EnterState();
            InputAttack.ReadInputToState();
            TimePassed = Time.time + 1.333f;
            Debug.Log("EnterAC");

        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed < Time.time && !IsExit)
            {
                IsExit = true;
                if(EnterFriendState(ScytheStore.AttackAA)) return;
            }

        }
        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("ExitAC");
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
    }
}
