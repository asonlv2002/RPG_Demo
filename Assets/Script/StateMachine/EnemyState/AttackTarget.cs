
using UnityEngine;
using ColliderContents;

namespace StateContents
{
    internal class AttackTarget : EnemyAction
    {
        MonoTargetAttack _monoTarget;
        TransFormContent _transForm;
        float timeAttack;
        public AttackTarget(StateCore stateContent,EnemyStateStore stateStore) : base(stateContent,stateStore)
        {
            var colliderCors = stateContent.MainCores.GetCore<ColliderCore>();
            _transForm = colliderCors.GetContentComponent<TransFormContent>();
            _monoTarget = colliderCors.GetContentComponent<MonoTargetAttack>();
        }
        public override void EnterState()
        {
            Debug.Log("AttackTarget");
            base.EnterState();
            timeAttack = 1f;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (timeAttack > 0)
            {
                timeAttack -= Time.deltaTime;
            }
            else if (EnterFriendState(StateStore.Move)) return;
        }

        public override bool ConditionEnterState()
        {
            return Vector3.Distance(_transForm.PlayerTransform.position, _monoTarget.Target.position) < 4f;
        }
    }
}
