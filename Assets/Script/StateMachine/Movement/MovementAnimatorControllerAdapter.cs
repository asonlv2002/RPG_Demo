namespace StateContents
{
    using AnimatorContent;
    internal class MovementAnimatorControllerAdapter : StateComponent
    {
        MovementController Movement;
        
        public MovementAnimatorControllerAdapter(AnimatorCore animatorContent)
        {
            Movement = animatorContent.GetContentComponent<MovementController>();
        }

        public void EnterAnimatorMovement()
        {
            Movement.EnterMovement();
        }
        public void EnterUnEquip()
        {
            Movement.EnterUnequip();
        }

        public void EnterEquip()
        {
            Movement.EnterEquip();
        }
    }
}
