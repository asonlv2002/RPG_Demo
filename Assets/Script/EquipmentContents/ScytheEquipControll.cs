using Item.ItemGameData;
using UnityEngine;

namespace Item.InEquipment
{
    internal class ScytheEquipControll : EquipmentController
    {
        public ScytheEquipControll(Transform positionEquipWeapon, WeaponData data) : base(positionEquipWeapon, data)
        {
            ItemRenderModel = new RenderWeaponOnHand(trasform, ItemData.Model);
        }
    }
}
