namespace EquipmentContents
{
    using AnimatorContent;
    using InputContents;
    using StateContents;

    internal class ScytheEquimentFactory : EquipWeaponFactory
    {
        public ScytheEquimentFactory(AnimatorCore animatorContent, InputCore inpuContent, StateCore stateContent,EquipmentCore equipmentCore) : base(animatorContent, inpuContent, stateContent, equipmentCore)
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
            var movementControll = _animatorContent.GetContentComponent<MovementController>();
            var attackControll = _animatorContent.GetContentComponent<AttackController>();
            movementControll.SetEquipAnimatorControll(_movementController.Scythe);
            movementControll.EnterEquip();
            attackControll.SetAttackController(_attackController.Scythe);

        }

        void InitInputContent()
        {
            _input.AddContentComponent(new InputAttackScyther());
        }

        void InitStateContent()
        {
            _state.AddContentComponent(new InputScytheAttackAdapter(_input));
            _state.AddContentComponent(new ScytheAnimatorControllerAdapter(_animatorContent));
            var scytheAttackStore = new ScytheAttackStateStore(_state);
            _state.AddContentComponent(scytheAttackStore);
            var movementStore = _state.GetContentComponent<MovementStateStore>();
            movementStore.AddAttackGroup(scytheAttackStore.ScytheAttackGroup);
            scytheAttackStore.AddMovement(movementStore.Movement);
            _state.EnterNextState(movementStore.Movement);

        }
    }
}
