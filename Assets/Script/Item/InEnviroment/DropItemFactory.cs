namespace Item.InEnviroment
{
    using ItemGameData;
    internal class DropItemFactory
    {
        private ItemInEnviroment _itemInEnviroment;
        private ItemInEnviromentPrefab _prefabs;
        public DropItemFactory(ItemInEnviromentPrefab prefabs)
        {
            _prefabs = prefabs;
        }
        ItemInEnviroment ItemFactory(ItemData itemData)
        {
            switch(itemData)
            {
                case ScytheData:
                    return _prefabs.ScythePrefab;
                case BowData:
                    return _prefabs.BowPrefab;
                default:
                    return null;
            }
        }

        public ItemInEnviroment GetItemInEnviroment(ItemData itemData)
        {
            _itemInEnviroment = ItemFactory(itemData);
            return _itemInEnviroment;
        }
    }
}
