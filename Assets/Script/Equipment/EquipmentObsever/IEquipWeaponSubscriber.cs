using Item.ItemGameData;

namespace Equipments
{
    internal interface IEquipWeaponSubscriber
    {
        void OnEquipWeapon(WeaponData weaponData);
    }
}
