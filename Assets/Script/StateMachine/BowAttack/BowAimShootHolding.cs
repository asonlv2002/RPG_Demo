namespace StateContents
{
    using UnityEngine;
    internal class BowAimShootHolding : BowAttack
    {
        public BowAimShootHolding(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = Animator.StringToHash("isShootHold");
        }

        public override void EnterState()
        {
            base.EnterState();
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Holding");
        }

        public override void UpdateState()
        {
            Debug.Log("Holding");
            if (!InputAttack.IsHolding)
            {
                if (EnterFriendState(BowStore.AimShootReslease)) return;

            }
            base.UpdateState();
        }
        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("Exit Holding");
            animator.SetBool(ActionParameter, !IsExit);
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return InputAttack.IsHolding;
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.IsHolding;
        }
    }
}
