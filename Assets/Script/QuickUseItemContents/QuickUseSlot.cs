namespace QuickUseItemContents
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    internal class QuickUseSlot : MonoBehaviour, IDropHandler
    {
        [field : SerializeField] public ItemVisual CurrentItem { get; private set; }
        [field : SerializeField] public RectTransform SlotTransform { get; private set; }

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

    }
}
