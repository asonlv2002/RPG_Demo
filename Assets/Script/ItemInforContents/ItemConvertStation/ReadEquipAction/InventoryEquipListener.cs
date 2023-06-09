using InventoryContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class InventoryEquipListener : IConvertItemStationListener
    {
        ItemInventoryStore _iventoryStore;
        private ItemInforCores _itemInforCores;
        ItemData currentItem;
        public InventoryEquipListener(ItemInforCores itemInforCores)
        {
            _itemInforCores = itemInforCores;
        }

        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            if(currentItem != itemData)
            {
                if(currentItem != null) _iventoryStore.AddItemData(currentItem);
                _iventoryStore.SubItemData(itemData);
                currentItem = itemData;
            }

        }

        void Generate()
        {
            if (_iventoryStore != null) return;
            _iventoryStore = _itemInforCores.MainCores.GetCore<InventoryCore>().GetContentComponent<ItemInventoryStore>();

        }
    }
}
