namespace Achitecture
{
    using AnimatorContent;
    using ColliderContents;
    using StatContents;
    using StateContents;
    using UnityEngine;
    using DamgeContents;
    internal class EnemyCores : MainCores
    {
        [SerializeField] AnimatorCore Animator;
        [SerializeField] ColliderCore Collider;
        [SerializeField] StateCore State;
        [SerializeField] StatCore Stat;
        [SerializeField] DamgeCores Damage;

        private void Start()
        {
            AddCore(Animator);
            AddCore(Collider);
            AddCore(State);
            AddCore(Stat);
            AddCore(Damage);
            Collider.InitMainCore(this);
            Animator.InitMainCore(this);
            State.InitMainCore(this);
            Stat.InitMainCore(this);
            Damage.InitMainCore(this);

        }
    }
}
