using AnimatorContent;
using InputContents;
using StateContents;

namespace EquipmentContents
{
    internal class BowEquipmentFactory : EquipWeaponFactory
    {
        public BowEquipmentFactory(AnimatorCore animatorContent, InputCore inpuContent, StateCore stateContent, EquipmentCore equipmentCore) : base(animatorContent, inpuContent, stateContent, equipmentCore)
        {
        }

        public override void InitEquipWeapon()
        {
            InitInput();
            InitAnimatorContent();
            InitStateContent();
        }

        void InitInput()
        {
            _input.AddContentComponent(new InputAttackBower());
        }
        void InitAnimatorContent()
        {
            var movementControll = _animatorContent.GetContentComponent<MovementController>();
            var attackControll = _animatorContent.GetContentComponent<AttackController>();
            movementControll.SetEquipAnimatorControll(_movementController.Bow);
            movementControll.EnterEquip();
            attackControll.SetAttackController(_attackController.Bow);
        }

        void InitStateContent()
        {
            _state.AddContentComponent(new InputBowAttackAdapater(_input));
            var bowStateSore = new BowStateStore(_state);
            _state.AddContentComponent(bowStateSore);
            var movementStore = _state.GetContentComponent<MovementStateStore>();
            movementStore.AddAttackGroup(bowStateSore.BowAttackGroup);
            bowStateSore.AddMovement(movementStore.Movement);
            _state.EnterNextState(movementStore.Movement);
        }

        public override void RemoveEquipWeapon()
        {

            var movementControll = _animatorContent.GetContentComponent<MovementController>();
            movementControll.EnterUnequip();

            _input.RemoveComponent<InputAttackBower>();

            _state.RemoveComponent<BowStateStore>();
            _state.RemoveComponent<InputBowAttackAdapater>();
            var movementStore = _state.GetContentComponent<MovementStateStore>();
            movementStore.AddAttackGroup(null);


        }
    }
}
