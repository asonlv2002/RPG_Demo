namespace StateContents
{
    internal class AttackScytheGroupState : ScytheAttack
    {
        ScytheAnimatorControllerAdapter AnimatorController;
        public AttackScytheGroupState(StateCore stateContent) : base(stateContent)
        {
            AnimatorController = stateContent.GetContentComponent<ScytheAnimatorControllerAdapter>();
        }
        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            base.EnterState();
        }
        public override bool ConditionEnterState()
        {
            return false;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
    }
}
