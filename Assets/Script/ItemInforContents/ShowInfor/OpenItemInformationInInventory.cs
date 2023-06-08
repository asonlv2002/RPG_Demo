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
            SetActiveButton();
            _buttonPresentation.OnOpenItemInformation(itemData);
            _buttonPresentation.Equip.SetItemData(itemData);
        }

        void SetActiveButton()
        {
            _buttonPresentation.Equip.gameObject.SetActive(true);
            _buttonPresentation.Unequip.gameObject.SetActive(false);
        }
    }
}
