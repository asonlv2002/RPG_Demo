namespace UIEquipmentContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using Item.ItemGameData;
    using InventoryContents;

    internal abstract class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] Image _icon;
        [SerializeField] GameObject _plusIcon;

        ItemData _itemData;
        UIEquipmentCores _core;
        EquipmentOpenItemInfor _openInfor;
        OpenCloseInventory _openCloseInventory;
        public void OnEquipItem(ItemData itemData)
        {
            if (itemData == _itemData) return;
            _itemData = itemData;
            _icon.sprite = _itemData.Information.Sprite;
            _icon.gameObject.SetActive(true);
            _plusIcon.SetActive(false);
        }
        public void OnUnequip()
        {
            _itemData = null;
            _icon.sprite = null;
            _icon.gameObject.SetActive(false);
            _plusIcon.SetActive(true);
        }
        public void SetCore(UIEquipmentCores uiEquipmentCores)
        {
            _core = uiEquipmentCores;
            _openInfor = _core.GetContentComponent<EquipmentOpenItemInfor>();
            _button.onClick.AddListener(OnClick);
        }

        protected void OnClick()
        {
            OpenItem(_itemData);
        }

        protected void OpenItem(ItemData itemData)
        {
            if(itemData)
            {
                _openInfor.OnOpenInformation(itemData);
            }else
            {
                GetOpenInventory();
                _openCloseInventory.OpenAction();
            }
        }

        void GetOpenInventory()
        {
            if (_openCloseInventory != null) return;
            _openCloseInventory = _core.MainCores.GetCore<InventoryCore>().GetContentComponent<OpenCloseInventory>();
        }

    }
}
