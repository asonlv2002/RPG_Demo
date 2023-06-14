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

        public bool CheckInut(AttackScytheInput input)
        {
            return Input.BeginInput(input);
        }

        public void EndReduceTime(bool isAttacking)
        {
            Input.EndTask(isAttacking);
        }

        public bool IsAttackEnegy => Input.IsAttackEnegy;

    }
}
