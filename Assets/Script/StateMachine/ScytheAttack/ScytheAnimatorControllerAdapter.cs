using AnimatorContent;

namespace StateContents
{

    internal class ScytheAnimatorControllerAdapter : StateComponent
    {
        AttackController AtatckController;
        public ScytheAnimatorControllerAdapter(AnimatorCore animatorContent)
        {
            AtatckController = animatorContent.GetContentComponent<AttackController>();
        }

        public void EnterAttackController()
        {
            AtatckController.EnterAttackControll();
        }
    }
}
