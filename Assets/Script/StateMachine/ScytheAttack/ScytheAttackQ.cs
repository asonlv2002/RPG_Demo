namespace StateContents
{
    internal class ScytheAttackQ : ScytheAttack
    {
        public ScytheAttackQ(StateCore stateContent) : base(stateContent)
        {
        }

        public override bool ConditionEnterState()
        {
            return Body.IsOnGround && InputAttack.AttackQ;
        }

        public override bool ConditionInitChildState()
        {
            return Body.IsOnGround && InputAttack.AttackQ;
        }
    }
}
