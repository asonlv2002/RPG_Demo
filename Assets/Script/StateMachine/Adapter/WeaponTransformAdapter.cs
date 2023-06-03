namespace StateContents
{
    using EquipmentContents;
    internal class WeaponTransformAdapter : StateComponent
    {
        WeaponEquipmentManager weaponEquipmentManager;
        public WeaponTransformAdapter(EquipmentCore equipmentCore)
        {
            weaponEquipmentManager = equipmentCore.GetContentComponent<WeaponEquipmentManager>();
        }

        public void Equip()
        {
            weaponEquipmentManager.Equip();
        }

        public void Unequip()
        {
            weaponEquipmentManager.UnEquip();
        }

        public bool IsUsingWeapon => weaponEquipmentManager.IsEquipping;
        public bool IsNoneUsingWeapon => weaponEquipmentManager.IsUnequipping;
    }
}
