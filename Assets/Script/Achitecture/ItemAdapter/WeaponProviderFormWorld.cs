using Item.Information;
using Item.ItemGameData;
using Item.InWorldSpace;

namespace ItemAdapter
{
    internal class WeaponProviderFormWorld : IItemAdapter
    {
        private ItemDataContainer _container;
        private ItemInformation _information;
        public WeaponProviderFormWorld(ItemWorldController itemWorldController)
        {
            _information = itemWorldController.Information;
            _container = ItemDataContainer.Intance;
        }

        public T TakeItemInformationID<T>() where T : WeaponData
        {
            var weapon = _container.EquipmentDatas.WeaponDatas.Weapons.Find(x => x.Information.IDItem == _information.IDItem);
            return weapon as T;
        }
    }
}
