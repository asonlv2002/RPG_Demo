namespace ItemInforContents
{
    using Item.ItemGameData;
    internal class OpenItemInformationInInventory : ISubOpenItemInformation
    {
        ButtonPresentation _buttonPresentation;
        public OpenItemInformationInInventory(ButtonPresentation buttonPresentation)
        {
            _buttonPresentation = buttonPresentation;
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            SetActiveButton(itemData);
            _buttonPresentation.OnOpenItemInformation(itemData);
        }

        void SetActiveButton(ItemData itemData)
        {
            switch(itemData)
            {
                case EquipmentData:
                    _buttonPresentation.UseAction.SetActive(false);
                    _buttonPresentation.Equip.SetActive(true);
                    _buttonPresentation.Unequip.SetActive(false);
                    _buttonPresentation.AddQuickUseAction.SetActive(false);
                    _buttonPresentation.Equip.SetItemData(itemData);
                    break;
                case ConsumbableData:
                    _buttonPresentation.UseAction.SetActive(true);
                    _buttonPresentation.AddQuickUseAction.SetActive(true);
                    _buttonPresentation.Equip.SetActive(false);
                    _buttonPresentation.Unequip.SetActive(false);

                    _buttonPresentation.UseAction.SetItemData(itemData);
                    _buttonPresentation.AddQuickUseAction.SetItemData(itemData);
                    break;
            }

        }
    }
}
