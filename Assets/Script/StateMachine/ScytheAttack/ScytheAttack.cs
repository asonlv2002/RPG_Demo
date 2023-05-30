namespace StateContents
{
    internal abstract class ScytheAttack : BaseState
    {
        protected InputScytheAttackAdapter InputAttack;
        protected ScytheAttack(StateCore stateContent) : base(stateContent)
        {
            InputAttack = StateContent.GetContentComponent<InputScytheAttackAdapter>();
        }
    }
}
