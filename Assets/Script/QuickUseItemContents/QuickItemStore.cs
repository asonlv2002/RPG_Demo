using Item.ItemGameData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace QuickUseItemContents
{
    [System.Serializable]
    class QuickItemStore : QuickUseComponent
    {
        [SerializeField] QuickUseCores _quickUseCore;
        [SerializeField] List<QuickUseSlot> quickUseSlots;
        [SerializeField] ItemVisual itemVisualPrefab;
        [SerializeField] RectTransform _containItemVisual;

        QuickUseSlot _slotAble;
        public override void OnAddComponent()
        {
            Debug.Log(quickUseSlots.Count);
        }

        public void AddItemData(ItemData itemData)
        {
            if(_slotAble.CurrentItem?.ItemData != null)
            {
                _slotAble.CurrentItem.AddCount(1);
            }else
            {
                var itemVisual = MonoBehaviour.Instantiate(itemVisualPrefab,_containItemVisual);
                itemVisual.Init(itemData);
                itemVisual.SetSlot(_slotAble);
                itemVisual.AddCount(1);
            }
        }



        void UseItem(ItemData itemData)
        {

        }

        public QuickUseSlot CheckAble(ItemData itemData)
        {
            var itemCosan = quickUseSlots.Find(x => x.CurrentItem?.ItemData == itemData);
            _slotAble = itemCosan ? itemCosan : quickUseSlots.Find(x => x.CurrentItem == null);
            return _slotAble;
            
        }
    }
}
