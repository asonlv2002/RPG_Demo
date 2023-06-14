namespace StateContents
{
    using UnityEngine;
    internal class BowAimRelease : BowAttack
    {
        float TimePassed;
        public BowAimRelease(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = Animator.StringToHash("isShootRelease");
        }

        public override void EnterState()
        {
            base.EnterState(); TimePassed = Time.time + 0.75f;
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Release");
        }

        public override void UpdateState()
        {
            if (Time.time > TimePassed)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.BowAimLoad)) return;
            }
            base.UpdateState();
        }
        public override void ExitState()
        {
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Exit Release");
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return !InputAttack.IsHolding;
        }
    }
}
