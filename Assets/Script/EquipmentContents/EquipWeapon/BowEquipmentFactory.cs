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
            var movementStore = _state.GetContentComponent<MovementStateStore>();
            _state.EnterNextState(movementStore.Movement);
        }
    }
}
