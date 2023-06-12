using UnityEngine;
namespace AnimatorContent
{
    using Achitecture;
    using EquipmentContents;
    internal class PlayerAnimator : AnimatorCore
    {
   
        [field: SerializeField] private MovementAnimatorController _animatorMovementControllers;
        [field: SerializeField] private AnimatorAttackContains _animatorAttackControllers;
        [field: SerializeField] private AnimatorEnterAnimation _animatorEnterAnimation;
        [SerializeField] protected Transform body;
        protected override void Awake()
        {
            base.Awake();
            AddContentComponent(_animatorMovementControllers);
            AddContentComponent(_animatorAttackControllers);
            AddContentComponent(_animatorEnterAnimation);
        }
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            var movementController = new MovementController(this);
            movementController.SetUnequipAnimatorControll(Animator.runtimeAnimatorController);
            movementController.EnterUnequip();
            AddContentComponent(new AttackController(this));
            AddContentComponent(movementController);

        }
        protected override void OnAnimatorMove()
        {
            base.OnAnimatorMove();
            if (Animator.applyRootMotion)
            {
                body.rotation = Animator.rootRotation;
                body.position += Animator.deltaPosition;
            }
        }

        void UnEquipWeapon()
        {
            //Read On Animation UnEquip;
            MainCores.GetCore<EquipmentCore>().GetContentComponent<WeaponEquipmentManager>().UnEquip();
        }

        void EquipWeapon()
        {
            //Read On Animation Equip;
            MainCores.GetCore<EquipmentCore>().GetContentComponent<WeaponEquipmentManager>().Equip();
        }

    }
}
