
namespace Item.InEquipment
{
    using ItemGameData;
    internal abstract class EquipmentController : IItem,IItemCreateModel
    {
        protected IWeaponEquipPosition ProviderEquipment;
        public ItemData ItemData { get; private set; }
        public IItemRender ItemRenderModel { get; protected set; }

        public EquipmentController(IWeaponEquipPosition equipPosition, ItemData data)
        {
            ProviderEquipment = equipPosition;
            ItemData = data;
        }
    }
}
