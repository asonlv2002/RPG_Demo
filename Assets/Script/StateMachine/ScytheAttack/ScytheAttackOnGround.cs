namespace StateContents
{
    internal class ScytheAttackOnGround : ScytheAttack
    {
        ScytheAnimatorControllerAdapter AnimatorController;
        public ScytheAttackOnGround(StateCore stateContent) : base(stateContent)
        {
            AnimatorController = stateContent.GetContentComponent<ScytheAnimatorControllerAdapter>();
        }
        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            base.EnterState();
        }
        public override void ExitState()
        {
            base.ExitState();
            InputAttack.ExitAttackInput();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
            Physiscal.Movement(0, 0);
        }
        public override bool ConditionEnterState()
        {
            return InputAttack.IsInputAttack;
        }

        public override bool ConditionInitChildState()
        {
            return false;
        }
        public override bool ConditionExitState()
        {
            foreach(var child in childStates)
            {
                if(!child.ConditionExitState() || child.ConditionInitChildState())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
