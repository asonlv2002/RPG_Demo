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
            _buttonPresentation.Equip.SetActive(false);
            _buttonPresentation.Unequip.SetActive(true);
            _buttonPresentation.Unequip.SetItemData(itemData);
            _buttonPresentation.OnOpenItemInformation(itemData);
            _buttonPresentation.UseAction.SetActive(false);
            _buttonPresentation.AddQuickUseAction.SetActive(false);
        }
    }
}
