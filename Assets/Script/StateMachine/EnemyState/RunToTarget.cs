namespace StateContents
{
    using AnimatorContent;
    using ColliderContents;
    using UnityEngine;

    internal class RunToTarget : EnemyAction
    {
        ////MonoTargetAttack _monoTarget;
        //TransFormContent _transForm;
        public RunToTarget(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent, stateStore)
        {
            //var colliderCors = StateContent.MainCores.GetCore<ColliderCore>();
            //_transForm = colliderCors.GetContentComponent<TransFormContent>();
            //_monoTarget = colliderCors.GetContentComponent<MonoTargetAttack>();
            ActionParameter = Animator.StringToHash("isRun");

        }
        public override void EnterState()
        {
            animator.SetBool(ActionParameter, true);
            base.EnterState();
            Debug.Log("RunToTarget");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Attack)) return;
            else if (EnterFriendState(StateStore.MoveToWarpPoint)) return;
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {

            base.FixedUpdateState();
            MoveToTarget();
        }

        void MoveToTarget()
        {
            ColliderCondition.CharacterTranform.forward = Vector3.Normalize(ColliderCondition.TargetAttack.position - ColliderCondition.CharacterTranform.position);
            ColliderCondition.CharacterTranform.position = Vector3.Slerp(ColliderCondition.CharacterTranform.position, ColliderCondition.TargetAttack.position, Time.fixedDeltaTime);
        }

        public override bool ConditionEnterState()
        {
            return ColliderCondition.ConditionRunToTarget();
        }
    }
}
