using AnimatorContent;

namespace StateContents
{

    internal class AttackControllerAdapter : StateComponent
    {
        AttackController AtatckController;
        public AttackControllerAdapter(AnimatorCore animatorContent)
        {
            AtatckController = animatorContent.GetContentComponent<AttackController>();
        }

        public void EnterAttackController()
        {
            AtatckController.EnterAttackControll();
        }
    }
}
