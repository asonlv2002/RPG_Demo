namespace InventoryContents
{
    using UnityEngine;
    using System.Collections.Generic;
    using Item.ItemGameData;

    [System.Serializable]
    internal class ItemInventoryStore : InventoryComponent
    {
        [SerializeField] List<ItemInventory> _itemInventories;
        [SerializeField] List<ItemData> _itemDatas;
        [SerializeField] InventoryCore _inventoryCore;

        public void AddItemData(ItemData itemData)
        {
            _itemDatas.Add(itemData);
        }

        public void Init()
        {
            foreach(var item in _itemInventories)
            {
                item.SetItemData(_itemDatas[0], _inventoryCore);
            }
        }

    }
}
