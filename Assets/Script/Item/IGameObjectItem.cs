
namespace Item
{
    using ItemGameData;
    internal interface IGameObjectItem
    {
        ItemData GetItemData();
        void InitItemData(ItemData itemData);
        void InitItemRender(IItemRender itemRender);

    }
}
