using UnityEngine;
using InputContents;
namespace StateContents
{
    internal class BowFireOne : BowAttack
    {
        float TimePassed;
        public BowFireOne(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isFireOne");
        }
        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            InputAttack.ReadInputToState();
            TimePassed = Time.time;
            Debug.Log("Enter BowFireOne");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed + animator.LenghtAction() < Time.time)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.BowFireTwo)) return;
            }
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("Exit BowFireOne");
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackBowInput.Fire) && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }
    }
}
