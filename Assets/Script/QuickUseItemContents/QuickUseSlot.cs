namespace QuickUseItemContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using Item.ItemGameData;

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
            OnClickUseItem.onClick.AddListener(UseItem);
        }
        public void OnDrop(PointerEventData eventData)
        {
            var checkItem = eventData.pointerDrag.GetComponent<ItemVisual>();
            if (checkItem)
            {
                checkItem.CurrentSlot.SetCurrentItem(null);
                checkItem.SetSlot(this);
            }

        }

        public void SetCurrentItem(ItemVisual itemVisual)
        {
            CurrentItem = itemVisual;
        }

        void AddCurrenItemData()
        {

        }

        void SubCurrenItemData()
        {

        }

        void UseItem()
        {
            Debug.Log("2002");
            Debug.Log(CurrentItem?.ItemData);
        }
    }
}
