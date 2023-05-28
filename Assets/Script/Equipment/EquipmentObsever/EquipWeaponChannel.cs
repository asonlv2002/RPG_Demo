using Item.ItemGameData;
using System.Collections.Generic;

namespace Equipments
{
    internal class EquipWeaponChannel : IEquipWeaponNotify
    {
        List<IEquipWeaponSubscriber> _subsribers;

        EquipWeaponFactory _factory;
        Entities.PlayerRootContent playerRootContent;
        public EquipWeaponChannel(Entities.PlayerRootContent mainContent)
        {
            _subsribers = new List<IEquipWeaponSubscriber>();
            playerRootContent = mainContent;
            _subsribers.Add(playerRootContent.InputAction);
            _subsribers.Add(playerRootContent.Animator);
        }
        public void EquipWeapon(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    _factory = new ScytheEquimentFactory(playerRootContent.Animator);
                    break;
            }
            _factory.InitEquipWeapon();

            foreach(IEquipWeaponSubscriber subscriber in _subsribers)
            {
                subscriber.OnEquipWeapon();
            }
        }
    }
}
