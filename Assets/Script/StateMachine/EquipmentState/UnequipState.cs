namespace StateContents
{
    using UnityEngine;
    internal class UnequipState : MovementState
    {
        float TimePassed;
        StatusEquipAdapter StatusEquipment;
        public UnequipState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isUnEquip");
            StatusEquipment = StateContent.GetContentComponent<StatusEquipAdapter>();
        }

        public override void EnterState()
        {
            base.EnterState();
            animator.SetBool(ActionParameter, true);
            IsExit = false;
            TimePassed = Time.time + 1.1f;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if(TimePassed < Time.time)
            {
                if (EnterFriendState(MovementStore.Idle)) return;
            }
        }

        public override void ExitState()
        { 
            StateContent.GetContentComponent<MovementAnimatorControllerAdapter>().EnterUnEquip();
            animator.SetBool(ActionParameter, false);
            IsExit = true;
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsEquipPressed && StatusEquipment.IsUsingWeapon;
        }
    }
}
