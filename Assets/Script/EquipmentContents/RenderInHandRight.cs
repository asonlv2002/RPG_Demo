

namespace Item.InEquipment
{
    using Information;
    using UnityEngine;

    internal class RenderInHandRight : RenderWeaponOnHand
    {
        private Transform _handRight;

        public RenderInHandRight(IProviderPosition positionEquipWeapon, ItemModel model) : base(positionEquipWeapon, model)
        {
            _handRight = ProviderPosition.HandRight();
        }

        public override void RenderModel()
        {
            var weapon = MonoBehaviour.Instantiate(Model.Prefab,_handRight);
            ResetTransform(weapon.transform);
        }
    }
}


