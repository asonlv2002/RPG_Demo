using UnityEngine;
using Item.Information;
namespace Item.ItemGameData
{
    internal abstract class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemInformation Information { get; private set; }
        [field: SerializeField] public ItemModel Model { get; private set; }
    }
}