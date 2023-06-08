using Item.ItemGameData;
using UIEquipmentContents;

namespace ItemInforContents
{
    internal class ReadEquipItemInEquipment : ItemInforComponent, IConvertItemStationSub
    {
        ButtonEquipmentGroup _buttonEquipmentGroup;
        EquipmentOpenItemInfor _equipmentOpenItemInfor;
        UIEquipmentCores _UIEquipment;

        public ReadEquipItemInEquipment(ItemInforCores itemInforCores)
        {
            _UIEquipment = itemInforCores.MainCores.GetCore<UIEquipmentCores>();
        }

        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            switch (itemData)
            {
                case WeaponData:
                    _buttonEquipmentGroup.Weapon.OnEquipItem(itemData);
                    break;
                
            }
            _equipmentOpenItemInfor.OnOpenInformation(itemData);
        }

        void Generate()
        {
            if (_buttonEquipmentGroup != null) return;
            _buttonEquipmentGroup = _UIEquipment.GetContentComponent<ButtonEquipmentGroup>();
            _equipmentOpenItemInfor = _UIEquipment.GetContentComponent<EquipmentOpenItemInfor>();
        }
    }
}
