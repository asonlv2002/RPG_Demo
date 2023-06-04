using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace InputContents
{
    internal class InputAttackScyther: InputComponent
    {
        private InputAttackScythe Input;
        private List<AttackScytheInput> InputAttackScytherQueue;
        private float deltaTimedDeleteInput = 0.01f;
        private float runTime;
        bool isAttacking;
        public InputAttackScyther()
        {
            Input = new InputAttackScythe();
            InputAttackScytherQueue = new List<AttackScytheInput>();
            InitilazationInput();
        }
        protected void InitilazationInput()
        {
            Input.Attack.Enable();
            //Input.Attack.Attack_E.started += ReadAttackE;
            Input.Attack.Shift.started += ReadAttackShift;
            Input.Attack.LeftMouse.started += ReadMouseLeft;
        }

        void ReadAttackE(InputAction.CallbackContext callbackContext)
        {
            //AddInput(AttackScytheInput.InputQ);
        }

        void ReadAttackShift(InputAction.CallbackContext callbackContext)
        {
        }

        void ReadMouseLeft(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.MouseLeftClick);
        }
        public void ReadInputToState()
        {
            InputAttackScytherQueue.RemoveAt(0);
        }
        void AddInput(AttackScytheInput input)
        {
            Debug.Log(input);
            InputAttackScytherQueue.Add(input);
            RunTimeReduce();
        }
        public bool BeginInput(AttackScytheInput input)
        {
            if (InputAttackScytherQueue.Count == 0) return false;
            return input == InputAttackScytherQueue[0];
        }

        async void RunTimeReduce()
        {
            runTime = deltaTimedDeleteInput;

            while (isAttacking == false)
            {
                await Task.Delay(10);
                runTime -= Time.deltaTime;
                if (runTime <= 0)
                {
                    Debug.Log("Delete");
                    ReadInputToState();
                    return;
                }

            }    
        }

        public void EndTask(bool _isAttacking)
        {
            isAttacking = _isAttacking;
        }

    }


    internal enum AttackScytheInput
    {
        MouseLeftClick,
        InputE,
        InputQ,
        Shift
    }
}
