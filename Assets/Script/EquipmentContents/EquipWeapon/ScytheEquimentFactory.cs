namespace EquipmentContents
{
    using AnimatorContent;
    using InputContents;
    using StateContents;

    internal class ScytheEquimentFactory : EquipWeaponFactory
    {
        public ScytheEquimentFactory(AnimatorCore animatorContent, InputCore inpuContent, StateCore stateContent) : base(animatorContent, inpuContent, stateContent)
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
            _animatorContent.AddContentComponent(new AttackController(_animatorContent,_attackController.Scythe));
            _animatorContent.AddContentComponent(new MovementController(_animatorContent, _movementController.Scythe));
        }

        void InitInputContent()
        {
            _input.AddContentComponent(new InputAttackScyther());
        }

        void InitStateContent()
        {
            _state.AddContentComponent(new InputScytheAttackAdapter(_input));
            _state.AddContentComponent(new MovementAnimatorControllerAdapter(_animatorContent));
            _state.AddContentComponent(new ScytheAnimatorControllerAdapter(_animatorContent));
            var scytheAttackStore = new ScytheAttackStateStore(_state);
            _state.AddContentComponent(scytheAttackStore);
            var movementStore = _state.GetContentComponent<MovementStateStore>();
            movementStore.Grounded.AddFriendState(scytheAttackStore.ScytheGroup);

            _state.EnterNextState(movementStore.Movement);

        }
    }
}
