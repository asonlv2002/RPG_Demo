namespace Item.Effects
{
    using UnityEngine;
    using StatContents;
    [CreateAssetMenu(menuName = "Item/Effect/GainHP")]
    internal class GainHp : Effect
    {
        [SerializeField] int HP;
    }
}
