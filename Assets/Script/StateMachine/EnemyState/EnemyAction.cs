using AnimatorContent;
using ColliderContents;

namespace StateContents
{
    class EnemyAction : BaseState
    {
        protected EnemyStateStore StateStore;
        protected ColliderCondition ColliderCondition;
        public EnemyAction(StateCore stateContent, EnemyStateStore stateStore) : base(stateContent)
        {
            StateStore = stateStore;
            animator = new AnimatorAdapter(stateContent.MainCores.GetCore<AnimatorCore>());
            ColliderCondition = new ColliderCondition(stateContent.MainCores.GetCore<ColliderCore>());
            UnityEngine.Debug.Log(ColliderCondition);
        }
    }
}
