using UnityEngine;
using Item.Information;
namespace Item.ItemGameData
{
    [CreateAssetMenu(menuName = "Item/Weapon Data")]
    internal class WeaponData : ScriptableObject
    {
        [field: SerializeField] public ItemInformation Information { get; private set; }
        [field: SerializeField] public ItemModel Model { get; private set; }
    }
}
