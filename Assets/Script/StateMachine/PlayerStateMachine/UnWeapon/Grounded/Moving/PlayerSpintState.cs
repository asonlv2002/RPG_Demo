using StatContents;
using UnityEngine;

namespace StateContents
{
    internal class PlayerSpintState : MovementState
    {
        MPStat MP;
        float time =1;
        SPEEDStat Speed;
        const float BUFF_SPEED_SPRINT = 2f;
        public PlayerSpintState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            var statCore = StateContent.MainCores.GetCore<StatCore>();
            MP = statCore.GetContentComponent<MPStat>();
            Speed = statCore.GetContentComponent<SPEEDStat>();
            ActionParameter = UnityEngine.Animator.StringToHash("isSprint");
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
        }

        public override void UpdateState()
        {
            DownMP();
            base.UpdateState();
            if(!InputMovement.IsSpintPressed)
            if (EnterFriendState(MovementStore.Run)) return;
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            var forward = Body.Forward() * InputMovement.DirectionMove * Speed.GetCurrentStatValue()*BUFF_SPEED_SPRINT;
            Physiscal.Movement(forward);
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }
        public override bool ConditionEnterState()
        {
            return InputMovement.IsSpintPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsSpintPressed;
        }
        void DownMP()
        {
            if (time < 0)
            {
                time = 1;
                Debug.Log("Down");
                MP.SubCurrentStateValue(10);
            }
            else if (time >= 0)
            {
                time -= Time.deltaTime;
            }
        }
    }
}
