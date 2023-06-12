using InputContents;
using UnityEngine;

namespace StateContents
{
    internal class BowFireTwo : BowAttack
    {
        float TimePassed;
        public BowFireTwo(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isFireTwo");
        }
        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            InputAttack.ReadInputToState();
            TimePassed = Time.time;
            Debug.Log("Enter BowFireTwo");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed + animator.LenghtAction() < Time.time)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.BowFireThree)) return;
            }
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("Exit BowFireTwo");
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
