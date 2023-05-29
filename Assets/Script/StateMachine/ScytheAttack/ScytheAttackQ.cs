namespace StateContent
{
    internal class ScytheAttackQ : ScytheAttack
    {
        public ScytheAttackQ(IStateContent stateContent) : base(stateContent)
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
