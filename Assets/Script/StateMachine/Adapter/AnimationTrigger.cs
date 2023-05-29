namespace StateContent
{
    internal class AnimationTrigger : StateComponent
    {
        UnityEngine.Animator _animator;
        public AnimationTrigger(UnityEngine.Animator animator)
        {
            _animator = animator;
        }

        public void EnableTrigger(int hash)
        {
            _animator.SetBool(hash, true);
        }

        public void DisableTrigger(int hash)
        {
            _animator.SetBool(hash, false);
        }
    }
}
