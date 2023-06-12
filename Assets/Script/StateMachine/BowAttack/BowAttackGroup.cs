namespace StateContents
{
    internal class BowAttackGroup : BowAttack
    {
        AttackControllerAdapter AnimatorController;
        StatusEquipAdapter _weaponEquipStatus;
        public BowAttackGroup(StateCore stateContent, BowStateStore bowStateStore) : base(stateContent, bowStateStore)
        {
            AnimatorController = stateContent.GetContentComponent<AttackControllerAdapter>();
            _weaponEquipStatus = stateContent.GetContentComponent<StatusEquipAdapter>();
        }

        public override void EnterState()
        {
            AnimatorController.EnterAttackController();
            animator.SetRootMotion(true);
            Physiscal.Movement(UnityEngine.Vector3.zero);
            InputAttack.EndReduceTime(true);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (BowStore.BowFireGroup.IsExit && BowStore.BowAimGroup.IsExit)
            {
                if (EnterFriendState(BowStore.Movement)) return;
            }
        }

        public override void ExitState()
        {
            InputAttack.EndReduceTime(false);
            animator.SetRootMotion(false);
            base.ExitState();
        }

        public override bool ConditionInitChildState()
        {
            return true;
        }

        public override bool ConditionEnterState()
        {
            if (!_weaponEquipStatus.IsUsingWeapon) return false;
            var childCondition = BowStore.BowFireGroup.ConditionEnterState() || BowStore.BowAimGroup.ConditionEnterState();
            return childCondition;
        }

        public override void InitilationChildrenState()
        {
            if (EnterChildState(BowStore.BowAimGroup)) return;
            else if (EnterChildState(BowStore.BowFireGroup)) return;
        }
    }
}
