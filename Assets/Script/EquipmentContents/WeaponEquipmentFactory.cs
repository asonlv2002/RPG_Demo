
namespace EquipmentContents
{
    using Item;
    using Item.InEquipment;
    using Item.ItemGameData;
    internal class WeaponEquipmentFactory
    {
        WeaponEquipmentManager _context;
        public WeaponEquipmentFactory(WeaponEquipmentManager weaponEquipment)
        {
            _context = weaponEquipment;
        }

        public IItem WeaponFactory(WeaponData weaponData)
        {
            switch (weaponData)
            {
                case ScytheData:
                    return new ScytheEquipControll(_context.RightHand, weaponData);
                case BowData:
                    return new BowEquipControll(_context.LeftHand, weaponData);
                default: 
                    return null;
            }

        }
    }
}
