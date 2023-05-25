namespace StateMachine
{
    using UnityEngine;
    using AnimationAction;
    internal abstract class AnimationIDAdapter : IStateAnimationTrigger
    {
        private Animator _animator;
        public AnimationIDAdapter(PlayerAnimator playerAnimator)
        {
            _animator = playerAnimator.Animator;
        }

        public void EnableTrigger(int animationParameter)
        {
            _animator.SetBool(animationParameter, true);
        }

        public void DisableTrigger(int animationParameter)
        {
            _animator.SetBool(animationParameter, false);
        }
    }
}