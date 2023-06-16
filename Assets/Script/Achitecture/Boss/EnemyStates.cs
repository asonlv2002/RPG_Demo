using Achitecture;

namespace StateContents
{
    internal class EnemyStates : StateCore
    {
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            var stateStore = new EnemyStateStore(this);
            AddContentComponent(stateStore);
            EnterNextState(stateStore.Move);
        }

        private void Update()
        {
            CurrentState.UpdateState();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdateState();
        }
    }
}
