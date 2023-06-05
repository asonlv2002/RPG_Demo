
namespace StateContents
{
    internal class BowAttackAimShootGroup : BowAttack
    {
        AttackControllerAdapter AnimatorController;
        public BowAttackAimShootGroup(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
             AnimatorController = stateContent.GetContentComponent<AttackControllerAdapter>();
        }
        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            base.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            IsExit = BowStore.AimShootLoad.IsExit && BowStore.AimShootHolding.IsExit && BowStore.AimShootReslease.IsExit;
            if (IsExit)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.Movement)) return;
            }
        }
        public override bool ConditionEnterState()
        {
            return BowStore.AimShootLoad.ConditionInitChildState();
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(BowStore.AimShootLoad)) return;
        }
    }
}
