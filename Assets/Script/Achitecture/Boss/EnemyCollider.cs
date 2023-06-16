using Achitecture;
using UnityEngine;
namespace ColliderContents
{
    internal class EnemyCollider : ColliderCore
    {
        [SerializeField] PointWarp _pointWarp;

        [SerializeField] MonoTargetAttack _targetAttack;
        [SerializeField] TransFormContent _characterContents;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_characterContents);
            AddContentComponent(_targetAttack);
            AddContentComponent(_pointWarp);
        }
    }
}
