
using UnityEngine;
using ColliderContents;

namespace StateContents
{
    internal class AttackTarget : EnemyAction
    {
        float timeAttack;
        int countAttack;
        public AttackTarget(StateCore stateContent,EnemyStateStore stateStore) : base(stateContent,stateStore)
        {
            countAttack = 0;
        }
        public override void EnterState()
        {
            SelectAttact();
            animator.SetBool(ActionParameter, true);
            base.EnterState(); 
            ColliderCondition.CharacterTranform.forward = Vector3.Normalize(ColliderCondition.TargetAttack.position - ColliderCondition.CharacterTranform.position);
            timeAttack = Time.time;
            Debug.Log("Hello");
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (Time.time > timeAttack + animator.LenghtAction())
            {
                if (EnterFriendState(StateStore.RunToTarget)) return;
                else if (EnterFriendState(StateStore.MoveToWarpPoint)) return;
                else if (EnterFriendState(StateStore.Idle)) return;
                else if (EnterFriendState(this)) return;

            }
        }

        public override void ExitState()
        {
            if(ColliderCondition.ConditionAttack())
            {
                countAttack = countAttack >= 2 ? 0 : countAttack + 1;
            }
            else
            {
                countAttack = 0;
            }
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override bool ConditionEnterState()
        {
            return ColliderCondition.ConditionAttack();
        }

        void SelectAttact()
        {
            switch(countAttack)
            {
                case 0:
                    ActionParameter = Animator.StringToHash("isBaseAttack");
                    return;
                case 1:
                    ActionParameter = Animator.StringToHash("isClawAttack");
                    return;
                case 2:
                    ActionParameter = Animator.StringToHash("isFlameAttack");
                    return;
            }
        }
    }
}
