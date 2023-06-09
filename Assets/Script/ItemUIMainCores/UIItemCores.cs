namespace Achitecture
{
    using UnityEngine;
    using InventoryContents;
    using ItemInforContents;
    using UIEquipmentContents;
    using OnOffUIContents;

    internal class UIItemCores : MainCores
    {
        [SerializeField] InventoryCore _inventory;
        [SerializeField] ItemInforCores _itemInfor;
        [SerializeField] UIEquipmentCores _equipment;
        [SerializeField] OpenCloseUICores _openClose;
        private void Start()
        {
            AddCore(_inventory);
            AddCore(_itemInfor);
            AddCore(_equipment);
            AddCore(_openClose);

            _inventory.InitMainCore(this);
            _equipment.InitMainCore(this);
            _itemInfor.InitMainCore(this);
            _openClose.InitMainCore(this);

        }
    }
}
