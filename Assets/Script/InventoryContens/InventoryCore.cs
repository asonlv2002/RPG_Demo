using UnityEngine;
using System.Collections.Generic;
using Item.ItemGameData;

namespace InventoryContens
{
    internal class InventoryCore : Achitecture.CoreContain<InvetoryComponent>
    {
        [SerializeField]List<ItemInventory> itemInventories;

        [SerializeField] ItemData _itemData;
        private void Start()
        {
            Debug.Log(2);
            foreach (var item in itemInventories)
            {
                item.SetItemData(_itemData, this);
            }
        }
        public void OnpenItem()
        {
            UnityEngine.Debug.Log("Open");
        }
    }
}
