using UnityEngine;

namespace StateContents
{
    internal class ScytheAttackEnenyStart : ScytheAttack
    {
        public ScytheAttackEnenyStart(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isEnegyStart");
        }

        public override void EnterState()
        {
            base.EnterState();
            IsExit = false;
            animator.SetBool(ActionParameter, !IsExit);
            Debug.Log("Enter Load");
            TimePassed = Time.time;
        }

        public override void UpdateState()
        {
            if (Time.time > TimePassed + animator.LenghtAction())
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackEnegyMid)) return;
            }
            if (!InputAttack.IsAttackEnegy)
            {
                IsExit = true;
            }
            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.Fly(2f);
        }

        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("Exit Load");
            animator.SetBool(ActionParameter, !IsExit);
            base.ExitState();
        }
        public override bool ConditionInitChildState()
        {
            return Body.IsOnGround && InputAttack.IsAttackEnegy;
        }
    }
}
