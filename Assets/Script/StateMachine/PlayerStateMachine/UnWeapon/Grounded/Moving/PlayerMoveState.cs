
namespace StateContents
{
    internal class PlayerMoveState : MovementState
    {

        public PlayerMoveState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {

        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(MovementStore.Idle)) return;
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();



        }
        public override void ExitState()
        {
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return MovementStore.Run.ConditionEnterState();
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(MovementStore.Run)) return;
        }
    }
}
