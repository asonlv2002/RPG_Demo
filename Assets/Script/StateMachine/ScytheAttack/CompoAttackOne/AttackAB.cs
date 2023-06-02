namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class AttackAB : ScytheAttack
    {
        public AttackAB(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
        }

        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
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

            Debug.Log("ExitAB");
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
