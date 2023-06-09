using InventoryContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class InventoryUnequipListener :  IConvertItemStationListener
    {
        ItemInventoryStore _iventoryStore;
        private ItemInforCores _itemInforCores;

        public InventoryUnequipListener(ItemInforCores itemInforCores)
        {
            _itemInforCores = itemInforCores;
        }

        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            _iventoryStore.AddItemData(itemData);
        }

        void Generate()
        {
            if (_iventoryStore != null) return;
            _iventoryStore = _itemInforCores.MainCores.GetCore<InventoryCore>().GetContentComponent<ItemInventoryStore>();

        }
    }
}
