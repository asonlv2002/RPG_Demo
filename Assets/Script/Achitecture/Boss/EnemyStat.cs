

namespace StatContents
{
    using Achitecture;
    using UnityEngine;
    internal class EnemyStat : StatCore
    {
        [SerializeField] HPStat _hpStat;
        [SerializeField] BossUIHp HpBar;
        [SerializeField] GameObject _victory;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            _hpStat.AddEventCurrenValueModify(HpBar.SetCurrentValue);
            _hpStat.AddEventMaxValueModify(HpBar.SetMaxValue);
            _hpStat.TriggerStat();

            AddContentComponent(_hpStat);
            _hpStat.OnZeroHp += () =>
            {
                _victory.gameObject.SetActive(true);
                Invoke("SetTimescale", 1f);
                Destroy(MainCores.gameObject, 0.5f);
            };
        }
        void SetTimescale()
        {
            Time.timeScale = 0f;
        }
    }
}
