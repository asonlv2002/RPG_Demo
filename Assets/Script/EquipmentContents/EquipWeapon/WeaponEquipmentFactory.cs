
namespace EquipmentContents
{
    using Item;
    using Item.InEquipment;
    using Item.ItemGameData;
    internal class WeaponEquipmentFactory
    {
        private PositionEquipStore _position;

        public WeaponEquipmentFactory(PositionEquipStore position)
        {
            _position = position;
        }

        public IItem WeaponFactory(WeaponData weaponData)
        {
            switch (weaponData)
            {
                case ScytheData:
                    return new ScytheEquipControll(_position.RightHand, weaponData);
                case BowData:
                    return new BowEquipControll(_position.LeftHand, weaponData);
                default: 
                    return null;
            }

        }
    }
}
