namespace StateContent
{
    using AnimatorContent;
    internal class MovementAnimatorControllerAdapter : StateComponent
    {
        IAnimatorContent _animatorContent;
        
        public MovementAnimatorControllerAdapter(IAnimatorContent animatorContent)
        {
            _animatorContent = animatorContent;
        }

        public void EnterAnimatorMovement()
        {
            _animatorContent.Animator.runtimeAnimatorController = _animatorContent.GetContentComponent<MovementAnimatorController>().Scythe;
        }
    }
}
