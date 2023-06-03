

namespace Item.InEquipment
{
    using Information;
    using UnityEngine;

    internal class RenderInHandRight : RenderWeaponOnHand
    {
        private Transform _handRight;

        public RenderInHandRight(Transform positionEquipWeapon, ItemModel model) : base(positionEquipWeapon, model)
        {
            _handRight = positionEquip;
        }

        public override void RenderModel()
        {
            var weapon = MonoBehaviour.Instantiate(Model.Prefab,_handRight);
            ModelTransForm = weapon.transform;
        }
    }
}


