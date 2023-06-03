namespace StateContents
{
    using UnityEngine;
    internal class UnequipState : MovementState
    {
        float TimePassed;
        WeaponTransformAdapter adapter;
        public UnequipState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isUnEquip");
            adapter = StateContent.GetContentComponent<WeaponTransformAdapter>();
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
                if (EnterFriendState(StateStore.Idle)) return;
            }
        }

        public override void ExitState()
        {
            adapter.Unequip();
            StateContent.GetContentComponent<MovementAnimatorControllerAdapter>().EnterUnEquip();
            animator.SetBool(ActionParameter, false);
            IsExit = true;
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsEquipPressed && adapter.IsUsingWeapon;
        }
    }
}
