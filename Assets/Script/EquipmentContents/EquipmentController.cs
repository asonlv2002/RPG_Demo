
namespace Item.InEquipment
{
    using ItemGameData;
    using UnityEngine;

    internal abstract class EquipmentController : IItem,IItemCreateModel
    {
        protected Transform trasform;
        public ItemData ItemData { get; private set; }
        public IItemRender ItemRenderModel { get; protected set; }

        public EquipmentController(Transform equipPosition, ItemData data)
        {
            trasform = equipPosition;
            ItemData = data;
        }
    }
}
