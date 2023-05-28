using UnityEngine.InputSystem;
namespace InputContent
{
    internal class InputAttackScyther: InputComponent, IInputAttackScythe
    {
        private InputAttackScythe Input;
        public InputAttackScyther()
        {
            Input = new InputAttackScythe();
            InitilazationInput();
        }

        protected void InitilazationInput()
        {
            Input.Attack.Enable();
        }

        public bool AttackQ => Input.Attack.Attack_Q.IsPressed();

        public bool AttackE => Input.Attack.Attack_E.IsPressed();
    }
}
