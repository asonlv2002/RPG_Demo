
using AnimatorContent;

namespace StateContents
{
    internal class ActionRender : StateComponent
    {
        public UnityEngine.Animator Animator { get; private set; }
        public ActionRender(AnimatorCore animator)
        {
            Animator = animator.Animator;
        }
    }
}
