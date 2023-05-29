using Item.ItemGameData;
using System.Collections.Generic;

namespace Equipments
{
    internal class EquipWeaponChannel : IEquipWeaponNotify
    {
        List<IEquipWeaponSubscriber> _subsribers;

        EquipWeaponFactory _factory;
        Entities.PlayerRootContent Maincontent;
        public EquipWeaponChannel(Entities.PlayerRootContent mainContent)
        {
            _subsribers = new List<IEquipWeaponSubscriber>();
            Maincontent = mainContent;
            _subsribers.Add(Maincontent.InputAction);
            _subsribers.Add(Maincontent.Animator);
        }
        public void EquipWeapon(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    _factory = new ScytheEquimentFactory(Maincontent.Animator,Maincontent.InputAction, Maincontent.StateMachine);
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
