namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class AttackAB : ScytheAttack
    {
        public AttackAB(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isAB");
        }

        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            animator.SetBool(ActionParameter,true);
            InputAttack.ReadInputToState();
            TimePassed = Time.time + 2;
            Debug.Log("EnterAB");
        }
        public override void UpdateState()
        {

            base.UpdateState();
            if (TimePassed < Time.time)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackAC)) return;
            }
        }
        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("ExitAB");
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.MouseLeftClick) && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.MouseLeftClick) && Body.IsOnGround;
        }
    }
}
