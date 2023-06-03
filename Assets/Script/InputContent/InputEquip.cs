using StateContents;
using UnityEngine.InputSystem;

namespace InputContents
{
    internal class InputEquip : InputComponent
    {
        StateCore stateCore;
        BaseState EquipWeapon;
        BaseState UnEquipWeapon;
        InputEquipment inputEquip;

        public InputEquip()
        {
            inputEquip = new InputEquipment();
            Init();
        }

        //public InputEquip(StateCore stateCore, BaseState equipWeapon, BaseState unEquipWeapon)
        //{
        //    inputEquip = new InputEquipment();
        //    EquipWeapon = equipWeapon;
        //    UnEquipWeapon = unEquipWeapon;
        //}

        void Init()
        {
            inputEquip.Equipment.Enable();
            inputEquip.Equipment.Equip.started += ReadInpuEquipment;
        }

        void ReadInpuEquipment(InputAction.CallbackContext callback)
        {
            UnityEngine.Debug.Log("2002");
        }

    }
}
