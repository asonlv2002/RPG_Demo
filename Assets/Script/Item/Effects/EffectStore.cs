namespace Item.Effects
{
    using UnityEngine;
    using System.Collections.Generic;
    [System.Serializable]
    internal class EffectStore
    {
        [field: SerializeField] public List<Effect> ItemEffects { get; private set; }
    }
}
