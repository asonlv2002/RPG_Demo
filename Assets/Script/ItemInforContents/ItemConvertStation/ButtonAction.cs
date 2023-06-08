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

        private void Awake()
        {
            ConvertItemStationSubs = new List<IConvertItemStationSub>();
            Debug.Log(ConvertItemStationSubs);
            _button.onClick.AddListener(OnClickEffect);
        }

        public void SetItemData(ItemData itemData)
        {
            _itemData = itemData;
        }

        public virtual void Init(ItemInforCores itemInforCores)
        {
            ItemInforCores = itemInforCores;
        }

        public void AddConvertItemStation(IConvertItemStationSub convertItem)
        {
            ConvertItemStationSubs.Add(convertItem);
        }

        public void OnConverStationItem(ItemData itemData)
        {
            foreach(IConvertItemStationSub convertItemStationSub in ConvertItemStationSubs)
            {
                convertItemStationSub.OnConverItemStation(itemData);
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
