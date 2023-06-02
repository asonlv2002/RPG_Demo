
namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackOnAir : ScytheAttack
    {
        public ScytheAttackOnAir(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            ActionParameter = Animator.StringToHash("isAir");
        }

        public override void EnterState()
        {
            IsExit = false;
            TimePassed = Time.time + 2.167f;
            animator.SetBool(ActionParameter, true);
            base.EnterState();
            Physiscal.StopOnAir(true);
            InputAttack.ReadInputToState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(TimePassed < Time.time && !IsExit)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackOnGround)) return;
            }

        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();

        }

        public override void ExitState()
        {
            IsExit = true;
            Physiscal.StopOnAir(false);
            animator.SetBool(ActionParameter, true);
            Debug.Log("ExitAttackAir");
            base.ExitState();
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE) && !Body.IsOnGround;
        }
        public override bool ConditionEnterState()
        {
            return ConditionInitChildState();
        }
    }
}
