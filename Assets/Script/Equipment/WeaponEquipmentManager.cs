using UnityEngine;
using Item.InEnviroment;
using Item.ItemGameData;
namespace Item.InEquipment
{
    [System.Serializable]
    internal class WeaponEquipmentManager : IEquipmentManager
    {
        public IWeaponEquipPosition providerPosition { get; private set; }
        WeaponBeHaviourFactory _weaponBehaviourFactory;
        WeaponPrefabFactory _weaponPrefabFactory;
        WeaponEquipmentFactory _weaponEquipmentFactory;
        public WeaponEquipmentManager(IProviderPosition providerPosition, IStoreWeapon storeWeapon)
        {
            this.providerPosition = providerPosition as IWeaponEquipPosition;
            _weaponEquipmentFactory = new WeaponEquipmentFactory(this);
        }

        public void Equip(IItem itemData)
        {
            var weaponData = itemData.ItemData as WeaponData;
            var weaponEquip = _weaponEquipmentFactory.WeaponFactory(weaponData);

            (weaponEquip as IItemCreateModel).ItemRenderModel.RenderModel();
        }
    }
}
