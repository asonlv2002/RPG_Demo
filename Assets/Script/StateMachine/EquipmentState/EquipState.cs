
namespace StateContents
{
    using UnityEngine;
    internal class EquipState : MovementState
    {
        float TimePassed;
        WeaponTransformAdapter adapter;
        public EquipState(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isEquip");
            adapter = StateContent.GetContentComponent<WeaponTransformAdapter>();
        }

        public override void EnterState()
        {
            base.EnterState();

            var movement = StateContent.GetContentComponent<MovementAnimatorControllerAdapter>();
            movement.EnterEquip();
            movement.EnterAnimatorMovement();
            animator.SetBool(ActionParameter, true);
            IsExit = false;
            TimePassed = Time.time + 1.25f;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (TimePassed < Time.time)
            {
                if (EnterFriendState(StateStore.Idle)) return;
            }
        }

        public override void ExitState()
        {
            adapter.Equip();

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
