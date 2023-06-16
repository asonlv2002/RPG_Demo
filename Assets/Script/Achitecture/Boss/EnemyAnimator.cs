namespace AnimatorContent
{
    using Achitecture;
    using UnityEngine;
    internal class EnemyAnimator : AnimatorCore
    {
        [SerializeField] AnimatorEnterAnimation _enterAnimation;

        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_enterAnimation);
        }
    }
}
