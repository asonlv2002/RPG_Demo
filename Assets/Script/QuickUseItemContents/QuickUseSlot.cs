namespace QuickUseItemContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using Item.ItemGameData;
    using InventoryContents;

    internal class QuickUseSlot : MonoBehaviour, IDropHandler
    {
        [field : SerializeField] public ItemVisual CurrentItem { get; private set; }
        [field : SerializeField] public RectTransform SlotTransform { get; private set; }
        [SerializeField] Button OnClickUseItem;
        [SerializeField] QuickUseCores _quickUseCores;

        private void Awake()
        {
            SlotTransform = GetComponent<RectTransform>();
            OnClickUseItem = GetComponent<Button>();
            OnClickUseItem.onClick.AddListener(AddItemFormInventory);
        }
        public void OnDrop(PointerEventData eventData)
        {
            var checkItem = eventData.pointerDrag.GetComponent<ItemVisual>();
            if (checkItem)
            {
                checkItem.CurrentSlot.SetCurrentItem(null);
                checkItem.SetQuickUseSlot(this);
            }

        }

        public void SetCurrentItem(ItemVisual itemVisual)
        {
            CurrentItem = itemVisual;
        }

        void AddItemFormInventory()
        {
            var openInvenTory = _quickUseCores.MainCores.GetCore<InventoryCore>().GetContentComponent<OpenCloseInventory>();
            openInvenTory.OpenAction();

        }
    }
}
