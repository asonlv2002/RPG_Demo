using StatContents;

namespace StateContents
{

    internal class PlayerRunBack : MovementState
    {
        SPEEDStat Speed;

        public PlayerRunBack(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            var statCore = StateContent.MainCores.GetCore<StatCore>();
            Speed = statCore.GetContentComponent<SPEEDStat>();

            ActionParameter = UnityEngine.Animator.StringToHash("isRunBack");
        }

        public override void EnterState()
        {
            base.EnterState();

            animator.SetBool(ActionParameter, true);
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            var forward = Body.Forward() * InputMovement.DirectionMove * Speed.GetCurrentStatValue()*0.5f;
            Physiscal.Movement(forward);
        }

        public override void UpdateState()
        {

            base.UpdateState();
            if (EnterFriendState(MovementStore.Run)) return;
        }

        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override bool ConditionEnterState()
        {
            UnityEngine.Debug.Log(InputMovement.DirectionMove);
            return InputMovement.DirectionMove < 0;
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }
    }
}
