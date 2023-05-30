using Item.ItemGameData;

namespace Item.InEquipment
{
    internal class ScytheEquipControll : EquipmentController
    {
        public ScytheEquipControll(IWeaponEquipPosition positionEquipWeapon, WeaponData data) : base(positionEquipWeapon, data)
        {
            ItemRenderModel = new RenderInHandRight(ProviderEquipment, ItemData.Model);
        }
    }
}
