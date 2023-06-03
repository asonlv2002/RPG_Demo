namespace StateContents
{
    using UnityEngine;
    internal class EquipWeapon : MovementState
    {
        float TimePassed;

        public EquipWeapon(StateCore stateContent, MovementStateStore stateTransition) : base(stateContent, stateTransition)
        {
            ActionParameter = Animator.StringToHash("isUnEquip");
        }

        public override void EnterState()
        {
            base.EnterState();
            StateStore.Idle.ExitState();
            Debug.Log(2002);
            animator.SetBool(ActionParameter, true);
            IsExit = false;
            TimePassed = Time.time + 2f;
        }
        public override void UpdateState()
        {
            base.UpdateState();
            Debug.Log(TimePassed < Time.time);
            if(TimePassed < Time.time)
            {
                if (EnterFriendState(StateStore.Idle)) return;
            }
        }

        public override void ExitState()
        {
            animator.SetBool(ActionParameter, false);
            IsExit = true;
            base.ExitState();
        }
    }
}
