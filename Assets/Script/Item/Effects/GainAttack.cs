namespace Item.Effects
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Item/ItemEffect/GainATK")]
    internal class GainAttack : ItemEffect
    {
        [field: SerializeField] public int Attack;
    }
}
