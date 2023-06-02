namespace AnimatorContent
{
    using UnityEngine;

    internal abstract class AnimatorCore : Achitecture.CoreContain<AnimatorComponent>
    {
        [field: SerializeField] public Animator Animator { get; private set; }

        public void SetRuntimeAnimator(RuntimeAnimatorController runtimeAnimatorController)
        {
            var currentRuntimeAniamtor = Animator.runtimeAnimatorController;
            if(currentRuntimeAniamtor != runtimeAnimatorController)
            {
                Animator.runtimeAnimatorController = runtimeAnimatorController;
            }
        }
        protected virtual void OnAnimatorMove()
        {

        }


    }
}
