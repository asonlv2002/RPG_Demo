
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
            _attackController = _animatorContent.GetContentComponet<AnimatorAttackContains>();
            _movementController = _animatorContent.GetContentComponet<AnimatorMovementControllers>();

            _input = inpuContent;
        }

        public abstract void InitEquipWeapon();
    }
}
