namespace InventoryContens
{
    using Item.ItemGameData;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    internal class ItemInventory : MonoBehaviour
    {
        [SerializeField] ItemData _itemData;
        [SerializeField] Image Icon;
        [SerializeField] TextMeshProUGUI countUI;
        [SerializeField] InventoryCore InventoryCore;
        [SerializeField] Button _openItem;

        int _count = 0;
        public void SetItemData(ItemData itemData, InventoryCore inventoryCore)
        {
            if (_itemData != null) return;
            _itemData = itemData;
            InventoryCore = inventoryCore;
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
            countUI.text = _count.ToString();
        }

        void CreateUI()
        {
            Icon.sprite = _itemData.Information.Sprite;
            _openItem.onClick.AddListener(OpenItem);
            AddCount(1);
        }

        public void OpenItem()
        {
            InventoryCore.OnpenItem();
        }
        
    }
}
