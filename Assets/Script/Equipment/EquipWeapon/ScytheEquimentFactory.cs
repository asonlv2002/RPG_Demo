namespace Equipments
{
    using AnimatorContent;
    using InputContent;
    using StateContent;

    internal class ScytheEquimentFactory : EquipWeaponFactory
    {
        MovementStateStore movementStateStore;
        ScytheAttackStateStore scytheAttackStateStore;
        public ScytheEquimentFactory(IAnimatorContent animatorContent, IInputContent inpuContent, IStateContent stateContent) : base(animatorContent, inpuContent, stateContent)
        {
        }

        public override void InitEquipWeapon()
        {
            InitAnimatorContent();
            InitInputContent();
            InitStateContent();
        }

        void InitAnimatorContent()
        {
            _animatorContent.AddContentComponent(new AttackController(_animatorContent.Animator,_attackController.Scythe));
            _animatorContent.AddContentComponent(new MovementController(_animatorContent.Animator, _movementController.Scythe));
            _animatorContent.AddContentComponent(new ScytheAttackParameter());
        }

        void InitInputContent()
        {
            _input.AddContentComponent(new InputAttackScyther());
        }

        void InitStateContent()
        {
            _state.AddContentComponent(new InputScytheAttackAdapter(_input));
            scytheAttackStateStore = new ScytheAttackStateStore(_state);
            _state.AddContentComponent(scytheAttackStateStore);
            movementStateStore = _state.GetContentComponent<MovementStateStore>();

            movementStateStore.Movement.AddFriendState(scytheAttackStateStore.AttackGroup);

        }
    }
}
