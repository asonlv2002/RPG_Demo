namespace InventoryContents
{
    using Item.ItemGameData;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    internal class ItemInventory : MonoBehaviour
    {

        [SerializeField] Image _icon;
        [SerializeField] TextMeshProUGUI _countUI;
        [SerializeField] Button _openItem;

        ItemData _itemData;
        public ItemData ItemData => _itemData;
        InventoryOpenItemInfor _openInfor;
        int _count = 0;

        public void SetItemData(ItemData itemData, InventoryCore inventoryCore)
        {
            if (_itemData != null) return;
            _itemData = itemData;
            _openInfor = inventoryCore.GetContentComponent<InventoryOpenItemInfor>();
            CreateUI();

        }

        public void AddCount(int count)
        {
              _count += count;
            OnModifyCount();
        }
        public void SubCount(int count)
        {
            _count -= count;
            OnModifyCount();
        }

        void OnModifyCount()
        {
            _countUI.text = _count.ToString();
        }

        void CreateUI()
        {
            _icon.sprite = _itemData.Information.Sprite;
            _openItem.onClick.AddListener(OpenItem);
            AddCount(1);
        }

        public void OpenItem()
        {
            _openInfor.OnOpenInformation(_itemData);
        }
        
    }
}
