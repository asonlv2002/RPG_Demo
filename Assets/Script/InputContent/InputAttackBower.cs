using UnityEngine.InputSystem;
using UnityEngine;
namespace InputContents
{
    class InputAttackBower : InputComponent
    {
        InputAttackBow bow;
        public bool IsHolding { get; private set; }
        public InputAttackBower()
        {
            bow = new InputAttackBow();
            bow.Attack.Enable();
            bow.Attack.Hold.started += StartHold;
            bow.Attack.Hold.performed += Holding;
            bow.Attack.Hold.canceled += EnHolding;
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
        void EnHolding(InputAction.CallbackContext context)
        {
            IsHolding = false;
        }

        public override void OnRemoveComponent()
        {
            bow.Attack.Disable();
            bow = null;
        }
    }
}
