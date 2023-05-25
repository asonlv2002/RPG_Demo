using Item.ItemGameData;
using System.Collections.Generic;

namespace Equipments
{
    internal class EquipWeaponChannel : IEquipWeaponNotify
    {
        List<IEquipWeaponSubscriber> _subsribers;
        public EquipWeaponChannel(Entities.PlayerRootContent mainContent)
        {
            _subsribers = new List<IEquipWeaponSubscriber>();
        }
        public void EquipWeapon(WeaponData weaponData)
        {
            foreach(var subscriber in _subsribers)
            {
                subscriber.OnEquipWeapon(weaponData);
            }
        }
    }
}
