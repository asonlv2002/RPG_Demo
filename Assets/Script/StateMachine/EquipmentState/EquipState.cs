
namespace StateContents
{
    using UnityEngine;
    internal class EquipState : MovementState
    {
        float TimePassed;
        StatusEquipAdapter adapter;
        public EquipState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isEquip");
            adapter = StateContent.GetContentComponent<StatusEquipAdapter>();
        }

        public override void EnterState()
        {
            base.EnterState();

            var movement = StateContent.GetContentComponent<MovementAnimatorControllerAdapter>();
            movement.EnterEquip();
            movement.EnterAnimatorMovement();
            animator.SetBool(ActionParameter, true);
            IsExit = false;
            TimePassed = Time.time; ;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed + animator.LenghtAction() < Time.time)
            {
                if (EnterFriendState(MovementStore.Idle)) return;
            }
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            IsExit = true;
            base.ExitState();
        }

        public override bool ConditionEnterState()
        {
            return InputMovement.IsEquipPressed && adapter.IsNoneUsingWeapon;
        }
    }
}
