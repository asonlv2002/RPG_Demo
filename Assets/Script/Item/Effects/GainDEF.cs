namespace Item.Effects
{
    using UnityEngine;
    using StatContents;
    [CreateAssetMenu(menuName = "Item/ItemEffect/GainDEF")]
    internal class GainDEF : ItemEffect
    {
        [SerializeField] int DEF;
    }
}
