namespace Achitecture
{
    using UnityEngine;
    using InventoryContents;
    using ItemInforContents;
    internal class UIItemCores : MainCores
    {
        [SerializeField] InventoryCore _inventory;
        [SerializeField] ItemInforCores _itemInfor;

        private void Start()
        {
            AddCore(_inventory);
            AddCore(_itemInfor);

            _itemInfor.InitMainCore(this);
            _inventory.InitMainCore(this);



        }
    }
}
