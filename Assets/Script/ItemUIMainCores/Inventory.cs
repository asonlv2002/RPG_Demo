namespace InventoryContents
{
    using UnityEngine;
    using System.Collections.Generic;
    using Item.ItemGameData;
    internal class Inventory : InventoryCore
    {
        [SerializeField] ItemInventoryStore _itemInventoryStore;
        [SerializeField] InventoryOpenItemInfor _openInfor;
        private void Start()
        {
            _openInfor = new InventoryOpenItemInfor(this);
            AddContentComponent(_openInfor);
            AddContentComponent(_itemInventoryStore);
            _itemInventoryStore.Init();


        }
    }
}
