
namespace AnimatorContent
{
    using UnityEngine;
    internal class MovementController : AnimatorComponent, IMovementController
    {
        private Animator _animator;
        private RuntimeAnimatorController _newRuntimeAnimatorController;

        public MovementController(Animator animator, RuntimeAnimatorController animatorControll)
        {
            _animator = animator;
            _newRuntimeAnimatorController = animatorControll;
        }
        public void EnterMovement()
        {
            _animator.runtimeAnimatorController = _newRuntimeAnimatorController;
        }
    }
}
