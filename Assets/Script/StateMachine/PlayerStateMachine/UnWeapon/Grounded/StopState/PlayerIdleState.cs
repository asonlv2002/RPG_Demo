﻿namespace StateContents
{
    internal class PlayerIdleState : MovementState
    {
        public PlayerIdleState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = UnityEngine.Animator.StringToHash("isIdle");
        }
        public override void EnterState()
        {
            base.EnterState();

            animator.SetBool(ActionParameter, true);
            Physiscal.Movement(UnityEngine.Vector3.zero);
        }
        public override void ExitState()
        {
            base.ExitState();
            animator.SetBool(ActionParameter, false);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (EnterFriendState(MovementStore.Move)) return;
            if(MovementStore.UnEquip.ConditionEnterState())
            {
                ExitState();
                StateContent.EnterNextState(MovementStore.UnEquip);
                return;
            }else
            if(MovementStore.Equip.ConditionEnterState())
            {
                ExitState();
                StateContent.EnterNextState(MovementStore.Equip);
                return;
            }
        }

        public override bool ConditionEnterState()
        {
            return !InputMovement.IsRunPressed;
        }

        public override bool ConditionInitChildState()
        {
            return !InputMovement.IsRunPressed;
        }
    }
}
