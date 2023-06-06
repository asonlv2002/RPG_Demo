using UnityEngine;

namespace StateContents
{
    internal class PlayerMoveState : MovementState
    {
        public PlayerMoveState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isMove");
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(StateStore.Idle)) return;
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.applyRootMotion = false;
            RenderAction(SpeedMove());
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            RenderAction(Mathf.Abs(SpeedMove()));
            Physiscal.Movement(Body.Forward().x* SpeedMove(), Body.Forward().z * SpeedMove());


        }
        public override void ExitState()
        {
            base.ExitState();
            RenderAction(0);
        }

        float SpeedMove()
        {
            float speedUp = InputMovement.IsSpintPressed ? 8 : 4;
            return InputMovement.DirectionMove*speedUp;
        }

        void RenderAction(float Speed)
        {
            animator.SetFloat(ActionParameter, Speed);
        }
        public override bool ConditionEnterState()
        {
            return InputMovement.IsRunPressed;
        }

        public override bool ConditionInitChildState()
        {
            return InputMovement.IsRunPressed;
        }
    }
}
