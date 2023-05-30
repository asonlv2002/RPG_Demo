
namespace Item.InEquipment
{
    using ItemGameData;
    internal class WeaponEquipmentFactory
    {
        WeaponEquipmentManager _context;
        public WeaponEquipmentFactory(WeaponEquipmentManager weaponEquipment)
        {
            _context = weaponEquipment;
        }

        public IItem WeaponFactory(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    return new ScytheEquipControll(_context.providerPosition, weaponData);
                case BowData:
                    return new BowEquipControll(_context.providerPosition, weaponData);
            }
            return null;
        }
    }
}
