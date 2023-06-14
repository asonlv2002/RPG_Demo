namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class AttackAA : ScytheAttack
    {
        public AttackAA(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isAA");
        }
        public override void EnterState()
        {

            IsExit = false;
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            InputAttack.ReadInputToState();
            TimePassed = Time.time;
            Debug.Log("EnterAA");
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(Time.time > TimePassed+ animator.LenghtAction())
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackAB)) return;
            }
        }
        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("ExitAA");
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
