using UnityEngine;

namespace AnimationAction
{
    internal class PlayerAnimator : Entities.BranchContent
    {
        [SerializeField] Animator _animator;
        public void SwitchAnimatorController(RuntimeAnimatorController runtimeAnimatorController)
        {
            _animator.runtimeAnimatorController = runtimeAnimatorController;
        }
        public Animator Animator => _animator;

        public AnimationIntHashs AnimationIntHashs { get; private set; }

        private void Awake()
        {
            AnimationIntHashs = new AnimationIntHashs();
        }

        public void SetAnimationHashWithWeapon(AnimationIntHashs animationHash)
        {
            AnimationIntHashs = animationHash;
        }

    }
}
