namespace StateContents
{
    using UnityEngine;
    internal class AttackCompoA : ScytheAttack
    {
        public AttackCompoA(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
        {
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
            base.ExitState();
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackAA)) return;
        }
    }
}
