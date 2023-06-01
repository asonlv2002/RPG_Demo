namespace StateContents
{
    internal class ScytheAttackOnGround : ScytheAttack
    {

        public ScytheAttackOnGround(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent,Store)
        {

        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
        }
        public override bool ConditionEnterState()
        {
            foreach (var childState in childStates)
            {
                if (childState.ConditionInitChildState()) return true;
            }
            return false;
        }

        public override bool ConditionInitChildState()
        {
            foreach (var childState in childStates)
            {
                if (childState.ConditionInitChildState()) return true;
            }
            return false;
        }
        public override bool ConditionExitState()
        {
            return currentChildState.ConditionExitState();
        }
    }
}
