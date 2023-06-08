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

        [SerializeField] ItemInventory itemInventoryPrefab;
        [SerializeField] Transform _inventoryContent;

        public void AddItemData(ItemData itemData)
        {
            _itemDatas.Add(itemData);
            var itemInventory = _itemInventories.Find(x => x.ItemData == itemData);
            if(itemInventory != null)
            {
                itemInventory.AddCount(1);
            }else
            {
                itemInventory = MonoBehaviour.Instantiate(itemInventoryPrefab, _inventoryContent);
                itemInventory.SetItemData(itemData, _inventoryCore);
                _itemInventories.Add(itemInventory);
            }
        }

        public void Init()
        {
            foreach (var item in _itemInventories)
            {
                item.SetItemData(_itemDatas[0], _inventoryCore);
            }
        }

        public void SubItemData(ItemData itemData)
        {
            var itemInventory = _itemInventories.Find(x => x.ItemData == itemData);
            _itemInventories.Remove(itemInventory);
            MonoBehaviour.Destroy(itemInventory.gameObject);
            //itemInventory.SubCount(1);

        }

    }
}
