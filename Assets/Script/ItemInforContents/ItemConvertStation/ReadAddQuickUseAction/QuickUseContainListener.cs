using Item.ItemGameData;
using QuickUseItemContents;
namespace ItemInforContents
{
    internal class QuickUseContainListener : IConvertItemStationListener
    {
        QuickItemStore _quickItemStore;
        ItemInforCores _inforCores;
        public QuickUseContainListener(ItemInforCores itemInforCores)
        {
            _inforCores = itemInforCores;
        }

        public void OnConverItemStation(ItemData itemData)
        {
            Generate();
            _quickItemStore.AddItemData(itemData);
        }

        void Generate()
        {
            if (_quickItemStore != null) return;
            _quickItemStore = _inforCores.MainCores.GetCore<QuickUseCores>().GetContentComponent<QuickItemStore>();
        }
    }
}
