using UnityEngine.InputSystem;

namespace StateContents
{
    internal class InputEquip : StateComponent
    {
        StateCore _stateCore;
        BaseState EquipWeapon;
        BaseState UnEquipWeapon;
        InputEquipment inputEquip;

        public InputEquip()
        {
            inputEquip = new InputEquipment();
            Init();
        }

        public InputEquip(StateCore stateCore)
        {
            inputEquip = new InputEquipment();
            _stateCore = stateCore;
            EquipWeapon = _stateCore.GetContentComponent<MovementStateStore>().Equip;
            Init();
        }

        void Init()
        {
            inputEquip.Equipment.Enable();
            inputEquip.Equipment.Equip.started += ReadInpuEquipment;
        }

        void ReadInpuEquipment(InputAction.CallbackContext callback)
        {
            UnityEngine.Debug.Log(_stateCore.CurrentState);
            _stateCore.EnterNextState(EquipWeapon);
        }

    }
}
