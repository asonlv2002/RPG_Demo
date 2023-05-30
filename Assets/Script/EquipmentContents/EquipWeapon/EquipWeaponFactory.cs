
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
        public EquipWeaponFactory(AnimatorCore animatorContent,InputCore inpuContent, StateCore stateContent)
        {
            _animatorContent = animatorContent;
            _attackController = _animatorContent.GetContentComponent<AnimatorAttackContains>();
            _movementController = _animatorContent.GetContentComponent<MovementAnimatorController>();

            _input = inpuContent;
            _state = stateContent;
        }
        public abstract void InitEquipWeapon();


    }
}
