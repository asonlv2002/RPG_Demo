namespace StateContents
{
    using StatContents;
    using UnityEngine;
    internal class PlayerRunState : MovementState
    {
        SPEEDStat Speed;

        public PlayerRunState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            var statCore = StateContent.MainCores.GetCore<StatCore>();
            Speed = statCore.GetContentComponent<SPEEDStat>();

            ActionParameter = UnityEngine.Animator.StringToHash("isRun");
        }

        public override void EnterState()
        {
            base.EnterState();

            animator.SetBool(ActionParameter, true);
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            var forward = Body.Forward() * InputMovement.DirectionMove * Speed.GetCurrentStatValue();
            Physiscal.Movement(forward);
        }

        public override void UpdateState()
        {

            base.UpdateState();
            if (EnterFriendState(MovementStore.Sprint)) return;
        }

        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.DirectionMove > 0;
        }

        public override bool ConditionInitChildState()
        {
            return ConditionEnterState();
        }

    }
}
