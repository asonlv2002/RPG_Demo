namespace StateContents
{
    using AnimatorContent;
    internal class MovementAnimatorControllerAdapter : StateComponent
    {
        AnimatorCore _animatorContent;
        
        public MovementAnimatorControllerAdapter(AnimatorCore animatorContent)
        {
            _animatorContent = animatorContent;
        }

        public void EnterAnimatorMovement()
        {
            _animatorContent.Animator.runtimeAnimatorController = _animatorContent.GetContentComponent<MovementAnimatorController>().Scythe;
        }
    }
}
