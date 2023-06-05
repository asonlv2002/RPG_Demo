using UnityEngine.InputSystem;
using UnityEngine;
namespace InputContents
{
    class InputAttackBower : InputComponent
    {
        InputAttackBow bow;
        bool isStartHold;
        bool isHolding;
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
            isStartHold = true;            
            Debug.Log("isStartHold "+ isStartHold);
        }
        void Holding(InputAction.CallbackContext context)
        {
            isStartHold = false;
            isHolding = true;

            Debug.Log("isHolding " + isHolding);
        }
        void EnHolding(InputAction.CallbackContext context)
        {
            isHolding = false;
            Debug.Log("isEndHolding " + isHolding);
        }
    }
}
