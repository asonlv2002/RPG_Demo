using Item.ItemGameData;
using Achitecture;
using InputContents;
using AnimatorContent;
using StateContents;
namespace EquipmentContents
{
    internal class ComponentOnEquipWeaponSetter 
    {
        MainCores _mainCores;
        EquipWeaponFactory _factory;

        InputCore _inputCore;
        AnimatorCore _animatorCore;
        StateCore _stateCore;
        EquipmentCore _equipmentCore;
        
        public ComponentOnEquipWeaponSetter(MainCores mainCores)
        {
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
                case BowData:
                    _factory = new BowEquipmentFactory(_animatorCore, _inputCore, _stateCore, _equipmentCore);
                    break;
            }
            _factory.InitEquipWeapon();
        }

        public void RemoveWeapon()
        {
            _factory.RemoveEquipWeapon();
        }
    }
}
