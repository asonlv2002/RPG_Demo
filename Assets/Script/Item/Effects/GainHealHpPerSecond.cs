using Achitecture;
using StatContents;
using UnityEngine;

namespace Item.Effects
{
    [CreateAssetMenu(menuName = "Item/Effect/GainHealHpPerSecond")]
    internal class GainHealHpPerSecond : Effect
    {
        [field: SerializeField] public int HealPerSecond;

        public override void EnableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HealHpPerSecond>().AddCurrentStatValue(HealPerSecond);
        }

        public override void DisableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HealHpPerSecond>().SubCurrentStateValue(HealPerSecond);
        }
    }
}
