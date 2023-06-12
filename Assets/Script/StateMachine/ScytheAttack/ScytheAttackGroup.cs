﻿namespace StateContents
{
    internal class ScytheAttackGroup : ScytheAttack
    {
        AttackControllerAdapter AnimatorController;
        StatusEquipAdapter _weaponEquipStatus;
        public ScytheAttackGroup(StateCore stateContent, ScytheAttackStateStore Store) : base(stateContent, Store)
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
            if (ScytheStore.AttackOnGround.IsExit && ScytheStore.AttackOnAir.IsExit)
            {
                if (EnterFriendState(ScytheStore.Movement)) return;
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
            var childCondition = ScytheStore.AttackOnGround.ConditionInitChildState() || ScytheStore.AttackOnAir.ConditionInitChildState();
            return childCondition;
        }
        public override void InitilationChildrenState()
        {
            if (EnterChildState(ScytheStore.AttackOnGround)) return;
            else if (EnterChildState(ScytheStore.AttackOnAir)) return;
        }
    }
}
