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

        public void OnOpenItemInformation(ItemData itemData)
        {
            _icon.sprite = itemData.Information.Sprite;
            _name.text = itemData.Information.Name;
            _direction.text = itemData.Information.Description;
        }
    }
}
