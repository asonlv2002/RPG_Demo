namespace Achitecture
{
    using AnimatorContent;
    using ColliderContents;
    using StateContents;
    using UnityEngine;
    internal class EnemyCores : MainCores
    {
        [SerializeField] AnimatorCore Animator;
        [SerializeField] ColliderCore Collider;
        [SerializeField] StateCore State;

        private void Start()
        {
            AddCore(Animator);
            AddCore(Collider);
            AddCore(State);
            Collider.InitMainCore(this);
            Animator.InitMainCore(this);
            State.InitMainCore(this);

        }
    }
}
