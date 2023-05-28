
namespace Equipments
{
    using AnimatorContent;
    internal abstract class EquipWeaponFactory
    {
        protected IAnimatorContent _animatorContent;
        protected AnimatorAttackContains _attackController;
        protected AnimatorMovementControllers _movementController;
        public EquipWeaponFactory(IAnimatorContent animatorContent)
        {
            _animatorContent = animatorContent;
            _attackController = _animatorContent.GetAimatorComponet<AnimatorAttackContains>();
            _movementController = _animatorContent.GetAimatorComponet<AnimatorMovementControllers>();
        }

        public abstract void InitEquipWeapon();
    }
}
