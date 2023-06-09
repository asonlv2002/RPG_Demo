namespace ItemInforContents
{
    using Item.ItemGameData;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    internal abstract class ButtonAction : MonoBehaviour, IConvertIttemStationSigner
    {
        [SerializeField] protected Button _button;
        [SerializeField] protected ItemInforCores ItemInforCores;
        protected ItemData _itemData;
        public List<IConvertItemStationListener> ConvertItemStationSubs { get; private set; } = new List<IConvertItemStationListener>();

        public void SetItemData(ItemData itemData)
        {
            _itemData = itemData;
        }

        public virtual void Init(ItemInforCores itemInforCores)
        {
            ItemInforCores = itemInforCores;
            _button.onClick.AddListener(OnClickEffect);
        }

        public void AddConvertItemStation(IConvertItemStationListener convertItem)
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

        public void RemoveConvertItemStation(IConvertItemStationListener convertItem)
        {
            ConvertItemStationSubs.Remove(convertItem);
        }

        protected virtual void OnClickEffect()
        {
            OnConverStationItem(_itemData);
        }
    }
}
