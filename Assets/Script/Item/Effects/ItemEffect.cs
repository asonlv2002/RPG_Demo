namespace Item.Effects
{
    using UnityEngine;
    using Achitecture;
    internal abstract class ItemEffect : ScriptableObject
    {
        [field :SerializeField] public string EffectDescription { get; private set; }
        public void ActiveEffect()
        {

        }
    }
}
