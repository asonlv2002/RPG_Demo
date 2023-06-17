using Achitecture;
using StatContents;
using UnityEngine;

namespace DamgeContents
{
    internal class EnemyDamageRecord : DamgeCores
    {
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            var hpStat = MainCores.GetCore<StatCore>().GetContentComponent<HPStat>();
            var damageCaculator = new DamgeCaculator();
            damageCaculator.OnDamageTaken += hpStat.SubCurrentStateValue;
            AddContentComponent(damageCaculator);

        }
    }
}
