
namespace AnimatorContent
{
    using UnityEngine;
    internal class MovementController : AnimatorComponent
    {
        private RuntimeAnimatorController runtimeAnimatorControll;
        AnimatorCore _animatorCore;
        public MovementController(AnimatorCore animatorCore, RuntimeAnimatorController animatorControll)
        {
            _animatorCore = animatorCore;
            runtimeAnimatorControll = animatorControll;
        }

        public void EnterMovement()
        {
            _animatorCore.SetRuntimeAnimator(runtimeAnimatorControll);
        }
    }
}
