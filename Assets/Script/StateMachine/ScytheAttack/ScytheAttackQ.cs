namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackQ : ScytheAttack
    {
        float TimeEnd;
        public ScytheAttackQ(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent,Store)
        {
            ActionParameter = Animator.StringToHash("isAttackQ");
        }
        public override void EnterState()
        {
            { IsExit = false; }
            base.EnterState();
            TimeEnd = Time.time + 2.067f;
            InputAttack.ReadInputToState();
            animator.SetBool(ActionParameter, true);
        }
        public override void UpdateState()
        {
            if (TimeEnd < Time.time && InputAttack.CheckInut(AttackScytheInput.InputAttackQ))
            {
                { IsExit = false; }
                base.EnterState();
                TimeEnd = Time.time + 2.067f;
                InputAttack.ReadInputToState();
            }else if(TimeEnd < Time.time)
            {
                { IsExit = true; }
            }
            base.UpdateState();

        }
        public override void ExitState()
        {
            Debug.Log("ExitQ");
            animator.SetBool(ActionParameter, false);
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputAttackQ) && Body.IsOnGround;
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputAttackQ) && Body.IsOnGround;
        }
    }
}
