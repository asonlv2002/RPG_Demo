using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

namespace InputContents
{
    class InputAttackBower : InputComponent
    {
        InputAttackBow bow;
        public bool IsHolding { get; private set; }
        private List<AttackBowInput> _attackBowInput;
        private RemoveInputControler _removeInputControler;
        public InputAttackBower()
        {

            bow = new InputAttackBow();
            bow.Attack.Enable();
            bow.Attack.Hold.started += StartHold;
            bow.Attack.Hold.performed += Holding;
            bow.Attack.Hold.canceled += EndHolding;
            bow.Attack.Fire.started += ReadAttackFire;
            _attackBowInput = new List<AttackBowInput>();
            _removeInputControler = new RemoveInputControler(ReadInputToState, 0.1f);
        }

        void StartHold(InputAction.CallbackContext context)
        {
            IsHolding = true;            
            Debug.Log("isStartHold "+ IsHolding);
        }
        void Holding(InputAction.CallbackContext context)
        {
            IsHolding = true;

            Debug.Log("isHolding " + IsHolding);
        }
        void EndHolding(InputAction.CallbackContext context)
        {
            IsHolding = false;
        }

        public override void OnRemoveComponent()
        {
            bow.Attack.Disable();
            bow = null;
        }

        void ReadAttackFire(InputAction.CallbackContext callbackContext)
        {
            AddInput(AttackBowInput.Fire);
        }

        void AddInput(AttackBowInput input)
        {
            Debug.Log(input);
            _attackBowInput.Add(input);
            _removeInputControler.RunTimeReduce();
        }

        public bool BeginInput(AttackBowInput input)
        {
            if (_attackBowInput.Count == 0) return false;
            return input == _attackBowInput[0];
        }

        public void ReadInputToState()
        {
            _attackBowInput.RemoveAt(0);
        }

        public void EndTask(bool _isAttacking)
        {
            _removeInputControler.EndTask(_isAttacking);
        }
    }

    internal enum AttackBowInput
    {
        Fire
    }
}
