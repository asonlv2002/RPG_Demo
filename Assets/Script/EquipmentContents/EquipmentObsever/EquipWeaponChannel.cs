using Item.ItemGameData;
using System.Collections.Generic;
using Achitecture;
using InputContents;
using AnimatorContent;
using StateContents;
namespace EquipmentContents
{
    internal class EquipWeaponChannel 
    {
        List<IEquipWeaponSubscriber> _subsribers;
        MainCores _mainCores;
        EquipWeaponFactory _factory;

        InputCore _inputCore;
        AnimatorCore _animatorCore;
        StateCore _stateCore;
        EquipmentCore _equipmentCore;
        
        public EquipWeaponChannel(MainCores mainCores)
        {
            _subsribers = new List<IEquipWeaponSubscriber>();
            _mainCores = mainCores;
            _animatorCore = _mainCores.GetCore<AnimatorCore>();
            _inputCore = _mainCores.GetCore<InputCore>();
            _stateCore = _mainCores.GetCore<StateCore>();
            _equipmentCore= _mainCores.GetCore<EquipmentCore>();

        }
        public void EquipWeapon(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    _factory = new ScytheEquimentFactory(_animatorCore, _inputCore, _stateCore, _equipmentCore);
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
