
namespace EquipmentContents
{
    using AnimatorContent;
    using InputContents;
    using StateContents;

    internal abstract class EquipWeaponFactory
    {
        protected AnimatorCore _animatorContent;
        protected AnimatorAttackContains _attackController;
        protected MovementAnimatorController _movementController;


        protected InputCore _input;
        protected StateCore _state;
        protected EquipmentCore _equipment;
        public EquipWeaponFactory(AnimatorCore animatorContent,InputCore inpuContent, StateCore stateContent,EquipmentCore equipmentCore)
        {
            _animatorContent = animatorContent;
            _attackController = _animatorContent.GetContentComponent<AnimatorAttackContains>();
            _movementController = _animatorContent.GetContentComponent<MovementAnimatorController>();

            _input = inpuContent;
            _state = stateContent;
            _equipment = equipmentCore;
        }
        public abstract void InitEquipWeapon();


    }
}
