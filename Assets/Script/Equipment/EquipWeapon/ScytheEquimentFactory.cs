namespace Equipments
{
    using AnimatorContent;
    internal class ScytheEquimentFactory : EquipWeaponFactory
    {

        public ScytheEquimentFactory(IAnimatorContent animatorContent) : base(animatorContent)
        {
            InitEquipWeapon();
        }

        public override void InitEquipWeapon()
        {
            InitAnimatorContent();
        }

        void InitAnimatorContent()
        {
            _animatorContent.AddAnimatorComponent(new AttackController(_animatorContent.Animator,_attackController.Scythe));
            _animatorContent.AddAnimatorComponent(new MovementController(_animatorContent.Animator, _movementController.Scythe));
            _animatorContent.AddAnimatorComponent(new ScytheAttackParameter());
           
        }
    }
}
