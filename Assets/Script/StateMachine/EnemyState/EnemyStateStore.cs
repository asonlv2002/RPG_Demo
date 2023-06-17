using UnityEngine;

namespace StateContents
{
    internal class EnemyStateStore : StateStore
    {
        public EnemyStateStore(StateCore stateContent) : base(stateContent)
        {

        }

        protected override void CreateStateContain()
        {
            RunToTarget = new RunToTarget(_stateContent, this);
            Attack = new AttackTarget(_stateContent, this);
            MoveToWarpPoint = new MoveToWarpPoint(_stateContent, this);
            Idle = new EnemyIdle(_stateContent, this);


        }

        public BaseState Attack { get; private set; }

        public BaseState RunToTarget { get; private set; }
        public BaseState MoveToWarpPoint { get; private set; }
        public BaseState Idle { get; private set; }


    }
}
