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
            TimePassed = Time.time;
            Debug.Log("EnterAC");

        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed + animator.LenghtAction() < Time.time && !IsExit)
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
            return InputAttack.CheckInut(AttackScytheInput.InputAttackQ) && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputAttackQ) && Body.IsOnGround;
        }
    }
}
