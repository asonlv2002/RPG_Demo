using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
namespace QuickUseItemContents
{
    class ItemVisual : MonoBehaviour, IDragHandler,IDropHandler,IBeginDragHandler,IEndDragHandler
    {
        [SerializeField] RectTransform RectTransform;
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Canvas canvas;
        bool _wasSwitched;
        [field : SerializeField] public QuickUseSlot CurrentSlot { get; private set; }

        private void Awake()
        {
            RectTransform = this.transform as RectTransform;
            SetSlot(CurrentSlot);
        }
        public void SetSlot(QuickUseSlot currentSlot)
        {
            CurrentSlot = currentSlot;
            CurrentSlot.SetCurrentItem(this);
            SetTranform(CurrentSlot.SlotTransform);
        }

        #region Drag
        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
            RectTransform.SetSiblingIndex(100);
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        #endregion

        #region Drop
        public void OnDrop(PointerEventData eventData)
        {
            var ponterDrop = eventData.pointerDrag;
            if(CheckItemVisual(ponterDrop, out var itemVisual))
            {
                OnSwitItemVisual(itemVisual);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_wasSwitched == false)
            {
                SetSlot(CurrentSlot);
            }

            canvasGroup.blocksRaycasts = true;
            RectTransform.SetSiblingIndex(0);
        }
        #endregion;

        bool CheckItemVisual(GameObject pointerDrop, out ItemVisual itemVisual)
        {
            var checkItem = pointerDrop?.GetComponent<ItemVisual>();
            itemVisual = checkItem;
            return itemVisual != null;
        }
        void OnSwitItemVisual(ItemVisual itemVisual)
        {
            var slot = itemVisual.CurrentSlot;
            itemVisual.SetSlot(this.CurrentSlot);
            this.SetSlot(slot);
            _wasSwitched = true;
        }
        void SetTranform(RectTransform slotTransfrom)
        {
            RectTransform.anchoredPosition = slotTransfrom.anchoredPosition;
        }
    }
}
