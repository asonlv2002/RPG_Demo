using ColliderContents;
using UnityEngine;

namespace StateContents
{
    internal class EnemyIdle : EnemyAction
    {
        public EnemyIdle(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent, stateStore)
        {

            ActionParameter = Animator.StringToHash("isIdle");
        }
        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.RunToTarget)) return;
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override bool ConditionEnterState()
        {
            return ColliderCondition.ConditionIdle();
        }
    }
}
