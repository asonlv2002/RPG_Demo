namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class AttackAC : ScytheAttack
    {
        public AttackAC(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
        }

        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            InputAttack.ReadInputToState();
            TimePassed = Time.time + 2;
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
