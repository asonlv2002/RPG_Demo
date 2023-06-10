using InventoryContents;
using Item.ItemGameData;
using QuickUseItemContents;

namespace ItemInforContents
{
    internal class InventoryAddQuickUseListener : IConvertItemStationListener
    {
        QuickItemStore _quickItemStore;
        ItemInventoryStore _iventoryStore;
        ItemInforCores _itemInforCores;
        OpenCloseItemInfor openCloseItemInfor;
        public InventoryAddQuickUseListener(ItemInforCores itemInforCores)
        {
            _itemInforCores = itemInforCores;
            openCloseItemInfor = _itemInforCores.GetContentComponent<OpenCloseItemInfor>();
        }
        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            if (_quickItemStore.CheckAble(itemData) != null)
            {
                _quickItemStore.AddItemData(itemData);
                _iventoryStore.SubItemData(itemData, openCloseItemInfor.CloseAction);
            }

        }

        void Generate()
        {
            if (_iventoryStore != null) return;
            _quickItemStore = _itemInforCores.MainCores.GetCore<QuickUseCores>().GetContentComponent<QuickItemStore>();
            _iventoryStore = _itemInforCores.MainCores.GetCore<InventoryCore>().GetContentComponent<ItemInventoryStore>();

        }
    }
}
