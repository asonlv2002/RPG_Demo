
namespace StateContents
{
    internal class BowAimGroup : BowAttack
    {
        public BowAimGroup(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
        }
        public override void EnterState()
        {
            IsExit = false;
            base.EnterState();
        }
        public override void UpdateState()
        {
            base.UpdateState();
            IsExit = !InputAttack.IsHolding && BowStore.BowAimReslease.IsExit;
            if (IsExit)
            {
                IsExit = true;
                if (EnterFriendState(BowStore.BowFireGroup)) return;
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            Physiscal.FloatOnGround(Body.FLoatDirection);
        }
        public override bool ConditionEnterState()
        {
            return BowStore.BowAimLoad.ConditionInitChildState();
        }
        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(BowStore.BowAimLoad)) return;
        }
    }
}
