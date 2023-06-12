using InputContents;
using UnityEngine;

namespace StateContents
{
    internal class BowFireThree : BowAttack
    {
        float TimePassed;
        public BowFireThree(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isFireThree");
        }
        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            InputAttack.ReadInputToState();
            TimePassed = Time.time;
            Debug.Log("Enter BowFireThree");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed + animator.LenghtAction() < Time.time)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.BowFireOne)) return;
            }
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            Debug.Log("Exit BowFireThree");
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
