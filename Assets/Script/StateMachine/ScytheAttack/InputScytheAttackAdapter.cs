using InputContents;

namespace StateContents
{
    internal class InputScytheAttackAdapter : StateComponent
    {
        InputAttackScyther Input;
        public InputScytheAttackAdapter(InputCore inputContent)
        {
            Input = inputContent.GetContentComponent<InputAttackScyther>();
        }

        public void ReadInputToState()
        {
            Input.ReadInputToState();
        }

        public void ExitAttackInput()
        {
            Input.ExitAttackInput();
        }

        public bool CheckInut(AttackScytheInput input)
        {
            return Input.BeginInput(input);
        }

        public bool IsInputAttack => Input.IsInputAttack;
    }
}
