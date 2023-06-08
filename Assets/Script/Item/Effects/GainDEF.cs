namespace Item.Effects
{
    using UnityEngine;
    using StatContents;
    [CreateAssetMenu(menuName = "Item/Effect/GainDEF")]
    internal class GainDEF : Effect
    {
        [SerializeField] int DEF;
    }
}
