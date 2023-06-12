using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace InputContents
{
    internal class InputAttackScyther: InputComponent
    {
        private InputAttackScythe Input;
        private List<AttackScytheInput> _attackScytheInput;

        RemoveInputControler removeInputControler;
        public InputAttackScyther()
        {
            Input = new InputAttackScythe();
            _attackScytheInput = new List<AttackScytheInput>();
            InitilazationInput();
            removeInputControler = new RemoveInputControler(ReadInputToState, 0.1f);
        }
        public override void OnAddComponent()
        {
            InitilazationInput();
        }
        protected void InitilazationInput()
        {
            Input.Attack.Enable();
            Input.Attack.LeftMouse.started += ReadMouseLeft;
        }

        void ReadMouseLeft(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.MouseLeftClick);
        }
        public void ReadInputToState()
        {
            _attackScytheInput.RemoveAt(0);
        }
        void AddInput(AttackScytheInput input)
        {
            Debug.Log(input);
            _attackScytheInput.Add(input);
            removeInputControler.RunTimeReduce();
        }
        public bool BeginInput(AttackScytheInput input)
        {
            if (_attackScytheInput.Count == 0) return false;
            return input == _attackScytheInput[0];
        }
        public void EndTask(bool _isAttacking)
        {
            removeInputControler.EndTask(_isAttacking);
        }
        public override void OnRemoveComponent()
        {
            Input.Disable();
            Input = null;
            _attackScytheInput.Clear();
        }

    }


    internal enum AttackScytheInput
    {
        MouseLeftClick,
        InputQ,
        Shift
    }
}
