using UnityEngine;
namespace AnimatorContent
{
    internal class AttackController : AnimatorComponent
    {
        private RuntimeAnimatorController curentAttackController;
        AnimatorCore _animatorCore;
        public AttackController(AnimatorCore animatorCore)
        {
            _animatorCore = animatorCore;
        }

        public void EnterAttackControll()
        {
            _animatorCore.SetRuntimeAnimator(curentAttackController);
        }

        public void SetAttackController(RuntimeAnimatorController runtimeAnimatorController)
        {
            curentAttackController = runtimeAnimatorController;
        }
    }
}
