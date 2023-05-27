using UnityEngine.InputSystem;
namespace InputModify
{
    internal class InputAttackScytheContent: InputAttack, IInputAttackScythe
    {
        private InputAttackScythe Input;
        public InputAttackScytheContent()
        {
            Input = new InputAttackScythe();
            InitilazationInput();
        }

        protected override void InitilazationInput()
        {
            Input.Attack.Enable();
        }

        public bool AttackQ => Input.Attack.Attack_Q.IsPressed();

        public bool AttackE => Input.Attack.Attack_E.IsPressed();
    }
}
