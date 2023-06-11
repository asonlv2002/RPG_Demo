namespace Item.Effects
{
    using UnityEngine;
    using StatContents;
    using Achitecture;

    [CreateAssetMenu(menuName = "Item/Effect/GainHP")]
    internal class GainHp : Effect
    {
        [SerializeField] int HP;
        public override void EnableEffect(MainCores targetEffect)
        {
            var hpStat = targetEffect.GetCore<StatCore>().GetContentComponent<HPStat>();
            hpStat.AddCurrentStatValue(HP);
        }
    }
}
