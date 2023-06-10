namespace InventoryContents
{
    using UnityEngine;
    using System.Collections.Generic;
    using Item.ItemGameData;
    using Achitecture;

    internal class Inventory : InventoryCore
    {
        [SerializeField] OpenCloseInventory _openCloseInventory;
        [SerializeField] ItemInventoryStore _itemInventoryStore;
        [SerializeField] InventoryOpenItemInfor _openInfor;

        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_openCloseInventory);
            AddContentComponent(_openInfor);
            AddContentComponent(_itemInventoryStore);

            gameObject.SetActive(false);
            _openCloseInventory.TransfomPresentation.OnClose();
        }
    }
}
