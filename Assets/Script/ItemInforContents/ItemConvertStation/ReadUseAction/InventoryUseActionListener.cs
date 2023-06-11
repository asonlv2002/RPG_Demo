using InventoryContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class InventoryUseActionListener : IConvertItemStationListener
    {
        ItemInventoryStore _iventoryStore;
        private ItemInforCores _itemInforCores;

        public InventoryUseActionListener(ItemInforCores itemInforCores)
        {
            _itemInforCores = itemInforCores;
        }

        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            _iventoryStore.SubItemData(itemData);
        }

        void Generate()
        {
            if (_iventoryStore != null) return;
            _iventoryStore = _itemInforCores.MainCores.GetCore<InventoryCore>().GetContentComponent<ItemInventoryStore>();

        }
    }
}
