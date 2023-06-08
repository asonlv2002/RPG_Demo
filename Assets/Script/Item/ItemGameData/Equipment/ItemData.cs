using UnityEngine;
using Item.Information;
using Item.Effects;

namespace Item.ItemGameData
{
    internal abstract class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemInformation Information { get; private set; }
        [field: SerializeField] public ItemModel Model { get; private set; }
        [field: SerializeField] public EffectStore Effects { get; private set; }

    }
}