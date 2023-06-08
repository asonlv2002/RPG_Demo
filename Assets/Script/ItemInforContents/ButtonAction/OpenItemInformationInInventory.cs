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
        }

        void SetActiveButton()
        {
            _buttonPresentation.EquipAction.gameObject.SetActive(true);
        }
    }
}
