namespace StateContent
{
    internal abstract class ScytheAttack : BaseState
    {
        protected InputScytheAttackAdapter InputAttack;
        protected ScytheAttack(IStateContent stateContent) : base(stateContent)
        {
            InputAttack = StateContent.GetContentComponent<InputScytheAttackAdapter>();
        }
    }
}
