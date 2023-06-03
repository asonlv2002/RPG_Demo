using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
namespace InputContents
{
    internal class InputAttackScyther: InputComponent
    {
        private InputAttackScythe Input;
        private List<AttackScytheInput> InputAttackScytherQueue;
        public InputAttackScyther()
        {
            Input = new InputAttackScythe();
            InputAttackScytherQueue = new List<AttackScytheInput>();
            InitilazationInput();
        }
        protected void InitilazationInput()
        {
            Input.Attack.Enable();
            Input.Attack.Attack_E.started += ReadAttackE;
            Input.Attack.Shift.started += ReadAttackShift;
            Input.Attack.LeftMouse.started += ReadMouseLeft;
        }

        void ReadAttackE(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.InputE);
        }

        void ReadAttackShift(InputAction.CallbackContext callbackContext)
        {
            ExitAttackInput();
        }

        void ReadMouseLeft(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.MouseLeftClick);
        }
        public void ReadInputToState()
        {
            InputAttackScytherQueue.RemoveAt(0);
        }

        public void ExitAttackInput()
        {
            InputAttackScytherQueue.Clear();
        }
        void AddInput(AttackScytheInput input)
        {
            Debug.Log(input);
            InputAttackScytherQueue.Add(input);
        }
        public bool BeginInput(AttackScytheInput input)
        {
            if (InputAttackScytherQueue.Count == 0) return false;
            return input == InputAttackScytherQueue[0];
        }

        public bool IsInputAttack => InputAttackScytherQueue.Count > 0;
    }

    internal enum AttackScytheInput
    {
        MouseLeftClick,
        InputE,
        Shift
    }
}
