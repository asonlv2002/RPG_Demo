using AnimatorContent;

namespace StateContent
{

    internal class ScytheAnimatorControllerAdapter : StateComponent
    {
        AttackController AtatckController;
        public ScytheAnimatorControllerAdapter(IAnimatorContent animatorContent)
        {
            AtatckController = animatorContent.GetContentComponent<AttackController>();
        }

        public void EnterAttackController()
        {
            AtatckController.EnterAttackControll();
        }
    }
}
