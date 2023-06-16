namespace StateContents
{
    using ColliderContents;
    using UnityEngine;

    internal class RunToTarget : EnemyAction
    {
        MonoTargetAttack _monoTarget;
        TransFormContent _transForm;
        public RunToTarget(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent, stateStore)
        {
            var colliderCors = stateContent.MainCores.GetCore<ColliderCore>();
            _transForm = colliderCors.GetContentComponent<TransFormContent>();
            _monoTarget = colliderCors.GetContentComponent<MonoTargetAttack>();

        }
        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("RunToTarget");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Attack)) return;
        }

        public override void FixedUpdateState()
        {

            base.FixedUpdateState();
            MoveToTarget();
        }

        void MoveToTarget()
        {
            _transForm.PlayerTransform.forward = _monoTarget.Target.position - _transForm.PlayerTransform.position;
            _transForm.PlayerTransform.position = Vector3.Slerp(_transForm.PlayerTransform.position, _monoTarget.Target.position, 2 * Time.fixedDeltaTime);
        }

        public override bool ConditionEnterState()
        {
            return Vector3.Distance(_transForm.PlayerTransform.position, _monoTarget.Target.position) >= 4f;
        }
    }
}
