using Item.ItemGameData;
using System.Collections.Generic;

namespace ItemInforContents
{
    internal class OpenItemInformationInEquipment : ISubOpenItemInformation
    {
        ButtonPresentation _buttonPresentation;
        public OpenItemInformationInEquipment(ButtonPresentation buttonPresentation)
        {
            _buttonPresentation = buttonPresentation;
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            _buttonPresentation.Equip.gameObject.SetActive(false);
            _buttonPresentation.Unequip.gameObject.SetActive(true);
            _buttonPresentation.Unequip.SetItemData(itemData);
            _buttonPresentation.OnOpenItemInformation(itemData);
        }
    }
}
