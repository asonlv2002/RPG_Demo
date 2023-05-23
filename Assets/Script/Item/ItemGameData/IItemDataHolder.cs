
namespace Item.ItemGameData
{
    internal interface IItemDataHolder
    {
        ItemData ReadItemData();

        void LoadItemData(ItemData itemData);
    }
}


