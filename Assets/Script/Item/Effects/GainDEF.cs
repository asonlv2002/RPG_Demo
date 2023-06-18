namespace Item.Effects
{
    using UnityEngine;
    using StatContents;
    using Achitecture;

    [CreateAssetMenu(menuName = "Item/Effect/GainDEF")]
    internal class GainDEF : Effect
    {
        [SerializeField] int DEF;

        public override void EnableEffect(MainCores targetEffect)
        {
            var defStat = targetEffect.GetCore<StatCore>().GetContentComponent<DEFStat>();
            defStat.AddCurrentStatValue(DEF);
        }
        public override void DisableEffect(MainCores targetEffect)
        {
            var defStat = targetEffect.GetCore<StatCore>().GetContentComponent<DEFStat>();
            defStat.SubCurrentStateValue(DEF);
        }
    }
}
