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
            Move = new RunToTarget(_stateContent, this);
            Attack = new AttackTarget(_stateContent, this);
        }

        public BaseState Attack { get; private set; }

        public BaseState Move { get; private set; }


    }
}
