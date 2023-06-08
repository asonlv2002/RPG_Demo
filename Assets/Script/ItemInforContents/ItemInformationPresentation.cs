namespace ItemInforContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Item.ItemGameData;

    [System.Serializable]
    internal class ItemInformationPresentation : ItemInforComponent,ISubOpenItemInformation
    {
        [SerializeField] Image _icon;
        [SerializeField] TextMeshProUGUI _name;
        [SerializeField] TextMeshProUGUI _direction;
        ItemData currentItemData;
        public void OnOpenItemInformation(ItemData itemData)
        {
            if (currentItemData != null && itemData == currentItemData) return;
            currentItemData = itemData;
            _icon.sprite = currentItemData.Information.Sprite;
            _name.text = currentItemData.Information.Name;
            _direction.text = currentItemData.Information.Description;
        }
    }
}
