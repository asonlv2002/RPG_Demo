namespace StateContents
{
    internal abstract class ScytheAttack : BaseState
    {
        protected InputScytheAttackAdapter InputAttack;
        protected ScytheAttackStateStore ScytheStore;
        protected PhysicAdapter Physiscal;
        protected BodyAdapter Body;
        protected float TimePassed;
        protected ScytheAttack(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent)
        {
            ScytheStore = Store;
            InputAttack = StateContent.GetContentComponent<InputScytheAttackAdapter>();
            Physiscal = StateContent.GetContentComponent<PhysicAdapter>();
            Body = StateContent.GetContentComponent<BodyAdapter>();
        }
    }
}
