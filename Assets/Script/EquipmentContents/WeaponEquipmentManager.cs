using Item.ItemGameData;
namespace Item.InEquipment
{
    using EquipmentContents;
    internal class WeaponEquipmentManager : IEquipmentManager
    {
        public IWeaponEquipPosition providerPosition { get; private set; }
        private IEquipWeaponNotify _equipWeaponNotify;
        WeaponBeHaviourFactory _weaponBehaviourFactory;
        WeaponEquipmentFactory _weaponEquipmentFactory;
        public WeaponEquipmentManager(IProviderPosition providerPosition, IEquipWeaponNotify equipWeaponNotify)
        {
            this.providerPosition = providerPosition as IWeaponEquipPosition;
            _weaponEquipmentFactory = new WeaponEquipmentFactory(this);
            _equipWeaponNotify = equipWeaponNotify;
        }

        public void Equip(IItem itemData)
        {
            var weaponData = itemData.ItemData as WeaponData;
            _equipWeaponNotify.EquipWeapon(weaponData);
            var weaponEquip = _weaponEquipmentFactory.WeaponFactory(weaponData);

            (weaponEquip as IItemCreateModel).ItemRenderModel.RenderModel();
        }
    }
}
