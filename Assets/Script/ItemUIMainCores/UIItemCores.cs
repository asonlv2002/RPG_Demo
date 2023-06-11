namespace Achitecture
{
    using UnityEngine;
    using InventoryContents;
    using ItemInforContents;
    using UIEquipmentContents;
    using OnOffUIContents;
    using QuickUseItemContents;
    using SignItemContents;

    internal class UIItemCores : MainCores
    {
        [SerializeField] InventoryCore _inventory;
        [SerializeField] ItemInforCores _itemInfor;
        [SerializeField] UIEquipmentCores _equipment;
        [SerializeField] OpenCloseUICores _openClose;
        [SerializeField] QuickUseCores _quickUse;
        [SerializeField] SignItemCores _signItem;
        private void Start()
        {
            AddCore(_inventory);
            AddCore(_itemInfor);
            AddCore(_equipment);
            AddCore(_openClose);
            AddCore(_quickUse);
            AddCore(_signItem);
            _itemInfor.InitMainCore(this);
            _equipment.InitMainCore(this);
            _inventory.InitMainCore(this);
            _quickUse.InitMainCore(this);
            _openClose.InitMainCore(this);
            _signItem.InitMainCore(this);

        }
    }
}
