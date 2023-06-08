namespace Achitecture
{
    using UnityEngine;
    using InventoryContents;
    using ItemInforContents;
    using UIEquipmentContents;

    internal class UIItemCores : MainCores
    {
        [SerializeField] InventoryCore _inventory;
        [SerializeField] ItemInforCores _itemInfor;
        [SerializeField] UIEquipmentCores _equipment;
        private void Start()
        {
            AddCore(_inventory);
            AddCore(_itemInfor);
            AddCore(_equipment);
            _equipment.InitMainCore(this);
            _itemInfor.InitMainCore(this);
            _inventory.InitMainCore(this);



        }
    }
}
