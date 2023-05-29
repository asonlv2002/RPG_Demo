using InputContent;

namespace StateContent
{
    internal class InputScytheAttackAdapter : StateComponent
    {
        InputAttackScyther Input;
        public InputScytheAttackAdapter(IInputContent inputContent)
        {
            Input = inputContent.GetContentComponent<InputAttackScyther>();
        }

        public bool AttackQ => Input.AttackQ;
        public bool AttackE => Input.AttackE;


    }
}
