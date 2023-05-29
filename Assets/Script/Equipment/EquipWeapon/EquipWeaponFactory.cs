
namespace Equipments
{
    using AnimatorContent;
    using InputContent;
    using StateContent;

    internal abstract class EquipWeaponFactory
    {
        protected IAnimatorContent _animatorContent;
        protected AnimatorAttackContains _attackController;
        protected AnimatorMovementControllers _movementController;


        protected IInputContent _input;
        protected IStateContent _state;
        public EquipWeaponFactory(IAnimatorContent animatorContent,IInputContent inpuContent, IStateContent stateContent)
        {
            _animatorContent = animatorContent;
            _attackController = _animatorContent.GetContentComponent<AnimatorAttackContains>();
            _movementController = _animatorContent.GetContentComponent<AnimatorMovementControllers>();

            _input = inpuContent;
            _state = stateContent;
        }
        public abstract void InitEquipWeapon();


    }
}
