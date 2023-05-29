
namespace Equipments
{
    using AnimatorContent;
    using InputContent;

    internal abstract class EquipWeaponFactory
    {
        protected IAnimatorContent _animatorContent;
        protected AnimatorAttackContains _attackController;
        protected AnimatorMovementControllers _movementController;


        protected IInputContent _input;
        public EquipWeaponFactory(IAnimatorContent animatorContent,IInputContent inpuContent)
        {
            _animatorContent = animatorContent;
            _attackController = _animatorContent.GetContentComponent<AnimatorAttackContains>();
            _movementController = _animatorContent.GetContentComponent<AnimatorMovementControllers>();

            _input = inpuContent;
        }

        public abstract void InitEquipWeapon();
    }
}
