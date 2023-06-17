
using ColliderContents;
using UnityEngine;
namespace StateContents
{
    internal class ColliderCondition
    {
        TransFormContent _transForm;
        PointWarp _pointWarp;
        MonoTargetAttack _targetAttack;

        public ColliderCondition(ColliderCore colliderCore) 
        {
            _transForm = colliderCore.GetContentComponent<TransFormContent>();
            _pointWarp = colliderCore.GetContentComponent<PointWarp>();
            _targetAttack = colliderCore.GetContentComponent<MonoTargetAttack>();
        }


        public Transform TargetAttack
        {
            get
            {
                var chekcDistanceToTagret = (int)Vector3.Distance(_transForm.PlayerTransform.position, _targetAttack.Target.position) <= 20.1f;
                var checkDistanceToWarpPoint = (int)Vector3.Distance(_transForm.PlayerTransform.position, _pointWarp.Point.position) <= 20.1f;
                return chekcDistanceToTagret && checkDistanceToWarpPoint ? _targetAttack.Target : null;
            }
        }

        public bool ConditionIdle()
        {
            return TargetAttack == null && (int)Vector3.Distance(_transForm.PlayerTransform.position, _pointWarp.Point.position) <= 0.1f;
        }

        public bool ConditionRunToTarget()
        {
            return TargetAttack != null && (int)Vector3.Distance(_transForm.PlayerTransform.position, _targetAttack.Target.position) >= 5.1f;
        }

        public bool ConditionAttack()
        {
            return TargetAttack != null && (int)Vector3.Distance(_transForm.PlayerTransform.position, _targetAttack.Target.position) < 5f;
        }

        public bool ConditionMoveToWarpPoint()
        {
            return TargetAttack == null;/* || Vector3.Distance(_transForm.PlayerTransform.position, _pointWarp.Point.position) >= 0.1f && Vector3.Distance(_transForm.PlayerTransform.position, _targetAttack.Target.position) <= 10f;*/
        }
        public Transform CharacterTranform => _transForm.PlayerTransform;

        public Transform WarpPoint => _pointWarp.Point;

        public bool ConditionExitMoveToWarpPoint()
        {
            return (int)Vector3.Distance(_transForm.PlayerTransform.position, _pointWarp.Point.position) <= 15f;
        }

    }
}
