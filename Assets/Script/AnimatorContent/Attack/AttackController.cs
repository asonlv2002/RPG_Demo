using UnityEngine;
namespace AnimatorContent
{
    internal class AttackController : AnimatorComponent
    {
        private RuntimeAnimatorController runtimeAnimatorControll;
        AnimatorCore _animatorCore;
        public AttackController(AnimatorCore animatorCore, RuntimeAnimatorController animatorControll)
        {
            _animatorCore = animatorCore;
            runtimeAnimatorControll = animatorControll;
        }

        public void EnterAttackControll()
        {
            _animatorCore.SetRuntimeAnimator(runtimeAnimatorControll);
        }
    }
}
