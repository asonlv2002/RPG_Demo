using Item.ItemGameData;
using UIEquipmentContents;

namespace ItemInforContents
{
    internal class UIEquipmentEquipListener : IConvertItemStationListener
    {
        ButtonEquipmentGroup _buttonEquipmentGroup;
        EquipmentOpenItemInfor _equipmentOpenItemInfor;
        OpenCloseUIEquipment _UIEquipmentOpenClose;
        UIEquipmentCores _UIEquipment;

        public UIEquipmentEquipListener(ItemInforCores itemInforCores)
        {
            _UIEquipment = itemInforCores.MainCores.GetCore<UIEquipmentCores>();
        }

        public void OnConverItemStation(ItemData itemData)
        {
            InitLate();
            FactoryEquipmentSlot(itemData);
            OpenUIEquipment();
            ReloadInforItem(itemData);
        }

        void InitLate()
        {
            if (_buttonEquipmentGroup != null) return;
            _buttonEquipmentGroup = _UIEquipment.GetContentComponent<ButtonEquipmentGroup>();
            _equipmentOpenItemInfor = _UIEquipment.GetContentComponent<EquipmentOpenItemInfor>();
            _UIEquipmentOpenClose = _UIEquipment.GetContentComponent<OpenCloseUIEquipment>();
        }

        void ReloadInforItem(ItemData itemData)
        {
            _equipmentOpenItemInfor.OnOpenInformation(itemData);

        }

        void OpenUIEquipment()
        {
            if (_UIEquipmentOpenClose.IsOpen == false) _UIEquipmentOpenClose.OpenAction();
        }
        void FactoryEquipmentSlot(ItemData itemData)
        {
            switch (itemData)
            {
                case WeaponData:
                    _buttonEquipmentGroup.Weapon.OnEquipItem(itemData);
                    break;

            }
        }
    }
}
