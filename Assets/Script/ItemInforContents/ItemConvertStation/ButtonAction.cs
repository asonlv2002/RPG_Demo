namespace ItemInforContents
{
    using Item.ItemGameData;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    internal abstract class ButtonAction : MonoBehaviour, IConvertIttemStationObsever
    {
        [SerializeField] protected Button _button;
        [SerializeField] protected ItemInforCores ItemInforCores;
        protected ItemData _itemData;
        public List<IConvertItemStationSub> ConvertItemStationSubs { get; private set; }


        public void SetItemData(ItemData itemData)
        {
            _itemData = itemData;
        }

        public virtual void Init(ItemInforCores itemInforCores)
        {
            ItemInforCores = itemInforCores;
            ConvertItemStationSubs = new List<IConvertItemStationSub>();
            _button.onClick.AddListener(OnClickEffect);
        }

        public void AddConvertItemStation(IConvertItemStationSub convertItem)
        {
            ConvertItemStationSubs.Add(convertItem);
        }

        public void OnConverStationItem(ItemData itemData)
        {
            foreach(var sub in ConvertItemStationSubs)
            {
                sub.OnConverItemStation(itemData);
            }
        }

        public void SubConvertItemStation(IConvertItemStationSub convertItem)
        {
            ConvertItemStationSubs.Remove(convertItem);
        }

        protected virtual void OnClickEffect()
        {
            OnConverStationItem(_itemData);
        }
    }
}
