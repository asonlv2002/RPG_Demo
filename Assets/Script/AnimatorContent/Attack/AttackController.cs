using UnityEngine;
namespace AnimatorContent
{
    internal class AttackController : AnimatorComponent
    {
        private Animator _animator;
        private RuntimeAnimatorController _animatorControll;

        public AttackController(Animator animator, RuntimeAnimatorController animatorControll)
        {
            _animator = animator;
            _animatorControll = animatorControll;
        }

        public void EnterAttackControll()
        {
            _animator.runtimeAnimatorController = _animatorControll;
        }
    }
}
