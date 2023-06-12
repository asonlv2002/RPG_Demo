using AnimatorContent;

namespace StateContents
{
    internal class AnimatorAdapter : StateComponent
    {
        AnimatorEnterAnimation _animatorEnterAnimation;
        public AnimatorAdapter(AnimatorCore animatorCore )
        {
            _animatorEnterAnimation = animatorCore.GetContentComponent<AnimatorEnterAnimation>();
        }

        public void SetBool(int hash,bool value)
        {
            _animatorEnterAnimation.SetBool(hash,value);
        }

        public float LenghtAction()
        {
             return _animatorEnterAnimation.LengthAction();
        }

        public void SetRootMotion(bool value)
        {
            _animatorEnterAnimation.SetRootMotion(value);
        }
        public void SetFloat(int hash, float value)
        {
            _animatorEnterAnimation.SetFloat(hash, value);
        }
    }
}
