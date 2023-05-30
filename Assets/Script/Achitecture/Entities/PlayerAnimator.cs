using UnityEngine;
namespace AnimatorContent
{
    using Achitecture;
    using EquipmentContents;

    internal class PlayerAnimator : AnimatorCore, IEquipWeaponSubscriber
    {
        [field: SerializeField] private MovementAnimatorController _animatorMovementControllers;
        [field: SerializeField] private AnimatorAttackContains _animatorAttackControllers;
        protected override void Awake()
        {
            base.Awake();
            AddContentComponent(_animatorMovementControllers);
            AddContentComponent(_animatorAttackControllers);
        }
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);

        }
        public void OnEquipWeapon()
        {

        }
    }
}
