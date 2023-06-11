
using Achitecture;
using StatContents;
using UnityEngine;

namespace Item.Effects
{
    [CreateAssetMenu(menuName = "Item/Effect/GainMp")]
    internal class GainMp : Effect
    {
        [field: SerializeField] public int Mp;

        public override void EnableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<MPStat>().AddCurrentStatValue(Mp);
        }

        public override void DisableEffect(MainCores targetEffect)
        {
            targetEffect.GetCore<StatCore>().GetContentComponent<MPStat>().SubCurrentStateValue(Mp);
        }
    }
}
