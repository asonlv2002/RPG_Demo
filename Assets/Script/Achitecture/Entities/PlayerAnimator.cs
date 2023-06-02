using UnityEngine;
namespace AnimatorContent
{
    using Achitecture;

    internal class PlayerAnimator : AnimatorCore
    {
        [field: SerializeField] private MovementAnimatorController _animatorMovementControllers;
        [field: SerializeField] private AnimatorAttackContains _animatorAttackControllers;
        [SerializeField] protected Transform body;
        protected override void Awake()
        {
            base.Awake();
            AddContentComponent(_animatorMovementControllers);
            AddContentComponent(_animatorAttackControllers);
        }
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);

        }
        protected override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
            if (Animator.applyRootMotion)
            {
                body.rotation = Animator.rootRotation;
                body.position += Animator.deltaPosition;
            }
        }

    }
}
