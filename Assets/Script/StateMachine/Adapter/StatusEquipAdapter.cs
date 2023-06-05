namespace StateContents
{
    using EquipmentContents;
    internal class StatusEquipAdapter : StateComponent
    {
        WeaponEquipmentManager weaponEquipmentManager;
        public StatusEquipAdapter(EquipmentCore equipmentCore)
        {
            weaponEquipmentManager = equipmentCore.GetContentComponent<WeaponEquipmentManager>();
        }

        public bool IsUsingWeapon => weaponEquipmentManager.IsEquipping;
        public bool IsNoneUsingWeapon => weaponEquipmentManager.IsUnequipping;
    }
}
