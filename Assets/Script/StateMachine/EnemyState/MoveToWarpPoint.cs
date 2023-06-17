namespace StateContents
{
    using ColliderContents;
    using UnityEngine;
    internal class MoveToWarpPoint : EnemyAction
    {
        //TransFormContent _transForm;
        //PointWarp _pointWarp;
        //MonoTargetAttack _targetAttack;
        public MoveToWarpPoint(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent, stateStore)
        {
            //var colliderCore = StateContent.MainCores.GetCore<ColliderCore>();
            //_transForm = colliderCore.GetContentComponent<TransFormContent>();
            //_pointWarp = colliderCore.GetContentComponent<PointWarp>();
            //_targetAttack = colliderCore.GetContentComponent<MonoTargetAttack>();
            ActionParameter = Animator.StringToHash("isMoveToWarp");
        }
        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Idle)) return;
            if (EnterFriendState(StateStore.Attack)) return;
        }
        public override bool ConditionEnterState()
        {
            return ColliderCondition.ConditionMoveToWarpPoint();/*Vector3.Distance(_transForm.PlayerTransform.position, _pointWarp.Point.position) > 10f;*/
        }

        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Move();
        }

        void Move()
        {
            ColliderCondition.CharacterTranform.forward = Vector3.Normalize(ColliderCondition.WarpPoint.position- ColliderCondition.CharacterTranform.position);
            ColliderCondition.CharacterTranform.position = Vector3.MoveTowards(ColliderCondition.CharacterTranform.position, ColliderCondition.WarpPoint.position,1.5f*Time.fixedDeltaTime);
        }
    }
}
