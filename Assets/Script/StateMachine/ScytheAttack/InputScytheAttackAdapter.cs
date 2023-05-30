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

        public bool AttackQ => Input.AttackQ;
        public bool AttackE => Input.AttackE;


    }
}
