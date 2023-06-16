namespace StateContents
{
    class EnemyAction : BaseState
    {
        protected EnemyStateStore StateStore;
        public EnemyAction(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent)
        {
            StateStore = stateStore;
        }
    }
}
