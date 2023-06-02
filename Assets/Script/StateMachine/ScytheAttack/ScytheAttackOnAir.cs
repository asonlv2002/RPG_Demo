
namespace StateContents
{
    using InputContents;
    using UnityEngine;
    internal class ScytheAttackOnAir : ScytheAttack
    {
        public ScytheAttackOnAir(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {

        }

        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
            Debug.Log("EnterAttackAir");
            InputAttack.ReadInputToState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(Body.IsTerrestrial)
            {
                IsExit = true;
                if (EnterFriendState(ScytheStore.AttackOnGround)) return;
            }

        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.GravityEffect(300f);
        }

        public override void ExitState()
        {
            IsExit = true;
            Debug.Log("ExitAttackAir");
            base.ExitState();
        }

        public override bool ConditionInitChildState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE) && !Body.IsTerrestrial;
        }
        public override bool ConditionEnterState()
        {
            return InputAttack.CheckInut(AttackScytheInput.InputE) && !Body.IsTerrestrial;
        }
    }
}
