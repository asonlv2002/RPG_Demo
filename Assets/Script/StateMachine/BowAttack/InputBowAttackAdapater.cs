
namespace StateContents
{
    using InputContents;
    internal class InputBowAttackAdapater : StateComponent
    {
        InputAttackBower _inputAttack;

        public InputBowAttackAdapater(InputCore inputCore)
        {
            _inputAttack = inputCore.GetContentComponent<InputAttackBower>();
        }

        public void EndReduceTime(bool value)
        {
            _inputAttack.EndTask(value);
        }

        public bool CheckInut(AttackBowInput input)
        {
            return _inputAttack.BeginInput(input);
        }

        public void ReadInputToState()
        {
            _inputAttack.ReadInputToState();
        }

        public bool IsHolding => _inputAttack.IsHolding;
    }
}
