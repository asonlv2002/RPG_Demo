using Item.ItemGameData;
using UIEquipmentContents;
using InventoryContents;
namespace ItemInforContents
{
    internal class ReadUnequipFormEquipment : ItemInforComponent, IConvertItemStationSub
    {
        ButtonEquipmentGroup _buttonEquipmentGroup;
        InventoryOpenItemInfor _inventoryOpenItemInfor;
        UIEquipmentCores _UIEquipment;
        public ReadUnequipFormEquipment(ItemInforCores itemInforCores)
        {
            _UIEquipment = itemInforCores.MainCores.GetCore<UIEquipmentCores>();
        }
        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            switch (itemData)
            {
                case WeaponData:
                    _buttonEquipmentGroup.Weapon.OnUnequip();
                    break;

            }
            _inventoryOpenItemInfor.OnOpenInformation(itemData);
        }

        void Generate()
        {
            if (_buttonEquipmentGroup != null) return;
            _buttonEquipmentGroup = _UIEquipment.GetContentComponent<ButtonEquipmentGroup>();
            _inventoryOpenItemInfor = _UIEquipment.MainCores.GetCore<InventoryCore>().GetContentComponent<InventoryOpenItemInfor>();
        }
    }
}
