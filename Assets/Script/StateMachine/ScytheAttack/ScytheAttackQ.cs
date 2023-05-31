namespace StateContents
{
    internal class ScytheAttackQ : ScytheAttack
    {
        float time;
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
            time = 2.067f;
            animator.SetBool(ActionParameter, false);
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            time -= UnityEngine.Time.fixedDeltaTime;
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

        public override bool ConditionExitState()
        {
            return time <= 0;
        }
    }
}
