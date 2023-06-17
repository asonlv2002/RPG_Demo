

namespace StatContents
{
    using Achitecture;
    using UnityEngine;
    internal class EnemyStat : StatCore
    {
        [SerializeField] HPStat _hpStat;
        [SerializeField] BossUIHp HpBar;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            _hpStat.AddEventCurrenValueModify(HpBar.SetCurrentValue);
            _hpStat.AddEventMaxValueModify(HpBar.SetMaxValue);
            _hpStat.TriggerStat();
            AddContentComponent(_hpStat);
        }
    }
}
