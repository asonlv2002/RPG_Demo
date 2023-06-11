namespace Item.Effects
{
    using Achitecture;
    using StatContents;
    using UnityEngine;
    [CreateAssetMenu(menuName = "Item/Effect/GainMaxHp")]
    internal class GainMaxHp : Effect
    {
        [field: SerializeField] public int MaxHp;

        public override void EnableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HPStat>().AddMaxStatValue(MaxHp);
        }
        public override void DisableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HPStat>().SubMaxStatValue(MaxHp);
        }
    }
}
