namespace Item.Effects
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Item/Effect/GainATK")]
    internal class GainAttack : Effect
    {
        [field: SerializeField] public int Attack;
    }
}
