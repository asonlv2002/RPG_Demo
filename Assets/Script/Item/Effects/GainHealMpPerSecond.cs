using Achitecture;
using StatContents;
using UnityEngine;

namespace Item.Effects
{
    [CreateAssetMenu(menuName = "Item/Effect/GainHealMpPerSecond")]
    internal class GainHealMpPerSecond : Effect
    {
        [field: SerializeField] public int HealMpPerSecond;

        public override void EnableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HealMpPerSecond>().AddCurrentStatValue(HealMpPerSecond);
        }

        public override void DisableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<HealMpPerSecond>().SubCurrentStateValue(HealMpPerSecond);
        }
    }
}
