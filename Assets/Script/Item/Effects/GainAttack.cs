namespace Item.Effects
{
    using Achitecture;
    using StatContents;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Item/Effect/GainATK")]
    internal class GainAttack : Effect
    {
        [field: SerializeField] public int Attack;

        public override void EnableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<ATKStat>().AddCurrentStatValue(Attack);
        }

        public override void DisableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<ATKStat>().SubCurrentStateValue(Attack);
        }
    }
}
