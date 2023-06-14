using UnityEngine;

namespace StateContents
{
    internal class ScytheAttackEnegyMid : ScytheAttack
    {
        public ScytheAttackEnegyMid(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isEnegyMid");
        }

        public override void EnterState()
        {
            base.EnterState();
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Holding");
            Physiscal.StopOnAir(!IsExit);
        }

        public override void UpdateState()
        {
            if (!InputAttack.IsAttackEnegy)
            {
                IsExit = true;
                //if (EnterFriendState(ScytheStore.AttackEnegyStart)) return;
            }
            base.UpdateState();
        }
        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("Exit Holding");
            animator.SetBool(ActionParameter, !IsExit);
            Physiscal.StopOnAir(!IsExit);
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.IsAttackEnegy;
        }
    }
}
