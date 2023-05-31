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
            Input.Attack.Attack_Q.started += ReadAttackQ;
            Input.Attack.Attack_E.started += ReadAttackE;
        }

        void ReadAttackQ(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.InputQ);
        }

        void ReadAttackE(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.InputE);
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
            var count = InputAttackScytherQueue.Count;
            if (count >0)
            {
                if (InputAttackScytherQueue[count - 1] == input) return;
            }
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
        InputQ,
        InputE
    }
}
