
using System;
namespace Equipments
{
    using Item.ItemGameData;
    internal interface IEquipWeaponSubscriber
    {
        Type WeaponType { get;}
        void OnEquipWeapon(WeaponData weaponData);
    }
}
