namespace StateContents
{
    using UnityEngine;
    internal class ScytheAttackCompo : ScytheAttack
    {
        public ScytheAttackCompo(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
            IsExit = true;
        }
        public override bool ConditionEnterState()
        {
            return ScytheStore.AttackAA.ConditionInitChildState();
        }

        public override bool ConditionInitChildState()
        {
            return ScytheStore.AttackAA.ConditionInitChildState();
        }

        public override void EnterState()
        {

            IsExit = false;
            base.EnterState();
        }
        public override void UpdateState()
        {
            IsExit = ScytheStore.AttackAA.IsExit && ScytheStore.AttackAB.IsExit && ScytheStore.AttackAC.IsExit;
            base.UpdateState();

        }
        public override void ExitState()
        {
            IsExit = true;
            base.ExitState();
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackAA)) return;
        }
    }
}
