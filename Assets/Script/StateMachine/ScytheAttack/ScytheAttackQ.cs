namespace StateContents
{
    internal class ScytheAttackQ : ScytheAttack
    {
        public ScytheAttackQ(StateCore stateContent) : base(stateContent)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isAttackQ");
        }
        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
            Physiscal.Movement(0, 0);
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
