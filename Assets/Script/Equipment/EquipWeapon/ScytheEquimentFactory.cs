namespace Equipments
{
    using AnimatorContent;
    using InputContent;

    internal class ScytheEquimentFactory : EquipWeaponFactory
    {

        public ScytheEquimentFactory(IAnimatorContent animatorContent,IInputContent inputContent) : base(animatorContent, inputContent)
        {
            InitEquipWeapon();
        }

        public override void InitEquipWeapon()
        {
            InitAnimatorContent();
        }

        void InitAnimatorContent()
        {
            _animatorContent.AddContentComponent(new AttackController(_animatorContent.Animator,_attackController.Scythe));
            _animatorContent.AddContentComponent(new MovementController(_animatorContent.Animator, _movementController.Scythe));
            _animatorContent.AddContentComponent(new ScytheAttackParameter());

            _input.AddContentComponent(new InputAttackScyther());
           
        }
    }
}
