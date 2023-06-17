namespace DamgeContents
{
    using StatContents;
    using UnityEngine;
    [System.Serializable]
    internal class TakeDamgeCalulator : DamgeComponent
    {
        [SerializeField] DamgeCores _damgeCores;
        HPStat _hpStat;
        DEFStat _defStat;

        public override void OnAddComponent()
        {
            var statCore = _damgeCores.MainCores.GetCore<StatCore>();
            _hpStat = statCore.GetContentComponent<HPStat>();
            _defStat = statCore.GetContentComponent<DEFStat>();
        }
        public void OnDamgeTrigger(GameObject cause)
        {
            if(cause.tag == "EnemyDamge")
            {
                int damage = 200 - _defStat.GetCurrentStatValue();
                _hpStat.SubCurrentStateValue(damage);
                DamagePopupGenerator.Instance.Generator(_damgeCores.transform.position, damage.ToString(), Color.yellow);
            }
        }

    }
}
