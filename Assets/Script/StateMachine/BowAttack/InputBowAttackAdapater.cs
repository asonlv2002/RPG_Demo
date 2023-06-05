
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

        public bool IsHolding => _inputAttack.IsHolding;
    }
}
