
using AnimatorContent;

namespace StateContent
{
    internal class ActionRender : StateComponent
    {
        public UnityEngine.Animator Animator { get; private set; }
        public ActionRender(IAnimatorContent animator)
        {
            Animator = animator.Animator;
        }
    }
}
