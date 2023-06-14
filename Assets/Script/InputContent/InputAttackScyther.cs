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

        public bool IsAttackEnegy { get; private set; }
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
            Input.Attack.Attack_Q.started += ReadInputQ;
            Input.Attack.EnegyAttack.started += ReadAttackEnegyStart;
            Input.Attack.EnegyAttack.canceled += ReadAttackEnegyEnd;
        }

        void ReadInputQ(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackScytheInput.InputAttackQ);
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

        void ReadAttackEnegyStart(InputAction.CallbackContext callbackContext)
        {
            IsAttackEnegy = true;
        }
        void ReadAttackEnegyEnd(InputAction.CallbackContext callbackContext)
        {
            IsAttackEnegy = false;
        }

    }


    internal enum AttackScytheInput
    {
        InputAttackQ,
        InputAttackHmmmm,
        Shift
    }
}
