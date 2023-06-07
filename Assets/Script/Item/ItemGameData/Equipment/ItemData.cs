using UnityEngine;
using Item.Information;
using System.Collections.Generic;
using Item.Effects;

namespace Item.ItemGameData
{
    internal abstract class ItemData : ScriptableObject
    {
        [field: SerializeField] public ItemInformation Information { get; private set; }
        [field: SerializeField] public ItemModel Model { get; private set; }
        [field: SerializeField] public List<ItemEffect> ItemEffects { get; private set; }

    }
}