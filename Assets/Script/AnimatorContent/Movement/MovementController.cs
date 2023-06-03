
namespace AnimatorContent
{
    using UnityEngine;
    internal class MovementController : AnimatorComponent
    {
        private RuntimeAnimatorController currentAnimatorControll;

        private RuntimeAnimatorController equipmentAnimatorControll;

        private RuntimeAnimatorController unequipmenAnimatorControll;
        AnimatorCore _animatorCore;

        
        public MovementController(AnimatorCore animatorCore)
        {
            _animatorCore = animatorCore;
        }

        public void EnterMovement()
        {
            if (_animatorCore.Animator.runtimeAnimatorController == currentAnimatorControll) return; 
            _animatorCore.Animator.runtimeAnimatorController = currentAnimatorControll;
        }

        public void SetUnequipAnimatorControll(RuntimeAnimatorController controll)
        {
            unequipmenAnimatorControll = controll;
        }

        public void SetEquipAnimatorControll(RuntimeAnimatorController controll)
        {
            equipmentAnimatorControll = controll;
        }

        public void EnterUnequip()
        {
            currentAnimatorControll = unequipmenAnimatorControll;
        }

        public void EnterEquip()
        {
            currentAnimatorControll = equipmentAnimatorControll;
        }



    }
}
