using UnityEngine;

namespace StateContents
{
    internal class ScytheAttackEnegyEnd : ScytheAttack
    {
        public ScytheAttackEnegyEnd(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isEnegyEnd");
        }

        public override void EnterState()
        {
            base.EnterState(); 
            TimePassed = Time.time;
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Release");
        }

        public override void UpdateState()
        {
            if (Time.time > TimePassed + animator.LenghtAction())
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackEnegyStart)) return;
            }
            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.Fly(-1.5f);
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Exit Release");
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return !InputAttack.IsAttackEnegy;
        }
    }
}
