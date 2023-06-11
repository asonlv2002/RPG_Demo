using Item.ItemGameData;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using EquipmentContents;
using Achitecture;

namespace QuickUseItemContents
{
    class ItemVisual : MonoBehaviour, IDragHandler,IDropHandler,IBeginDragHandler,IEndDragHandler
    {
        RectTransform RectTransform;
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Canvas canvas;
        [SerializeField] Button _onClick;
        [SerializeField] Image _icon;
        [SerializeField] TextMeshProUGUI _countText;

        UseConsumableItem _useItem;
        int _countItem;

        bool _wasSwitched;
        public ItemData ItemData { get; private set; }
        public QuickUseSlot CurrentSlot { get; private set; }

        public void Init(ItemData itemData)
        {
            ItemData = itemData;
            _icon.sprite = ItemData.Information.Sprite;
            RectTransform = this.transform as RectTransform;
            this.gameObject.SetActive(true);
            _onClick.onClick.AddListener(UseItem);
            InitLate();
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
                SetQuickUseSlot(CurrentSlot);
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


        public void SetQuickUseSlot(QuickUseSlot currentSlot)
        {
            CurrentSlot = currentSlot;
            CurrentSlot.SetCurrentItem(this);
            RectTransform.anchoredPosition = CurrentSlot.SlotTransform.anchoredPosition;
        }
        void OnSwitItemVisual(ItemVisual itemVisual)
        {
            var slot = itemVisual.CurrentSlot;
            itemVisual.SetQuickUseSlot(this.CurrentSlot);
            this.SetQuickUseSlot(slot);
            _wasSwitched = true;
        }

        public void AddCount(int value)
        {
            _countItem += value;
            _countText.text = _countItem.ToString();
        }

        public void SubCount(int value)
        {
            _countItem -= value;
            _countText.text = _countItem.ToString();
        }

        void UseItem()
        {

            _useItem.UseItem(ItemData);
            SubCount(1);
            if(_countItem ==0)
            {
                CurrentSlot.SetCurrentItem(null);
                Destroy(gameObject);
            }
        }

        void InitLate()
        {
            if(_useItem == null)
            {
                _useItem = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().GetContentComponent<UseConsumableItem>();
            }
        }
    }
}
