using Item.ItemGameData;
using ItemInforContents;

namespace UIEquipmentContents
{
    internal class ReadConvertEquipItem : UIEquipmentComponent, IConvertItemStationSub
    {
        UIEquipmentCores UIEquipmentCores;
        ButtonEquipmentGroup _buttonEquipmentGroup;
        public ReadConvertEquipItem(UIEquipmentCores uIEquipmentCores)
        {
            UIEquipmentCores = uIEquipmentCores;
            _buttonEquipmentGroup = UIEquipmentCores.GetContentComponent<ButtonEquipmentGroup>();
        }

        public void OnConverItemStation(ItemData itemData)
        {
            switch(itemData)
            {
                case WeaponData:
                    _buttonEquipmentGroup.Weapon.OnEquipItem(itemData);
                    break;
                
            }
        }
    }
}
