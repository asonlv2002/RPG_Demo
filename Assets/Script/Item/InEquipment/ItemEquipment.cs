using UnityEngine;
namespace Item.InEquipment
{
    using Item.Information;
    using ItemGameData;
    internal abstract class ItemEquipment : MonoBehaviour
    {
        ItemData _itemData;
        ISetPosition setPosition;
        IRenderModel renderModel;

        public void LoadItemData(ItemData item) => _itemData = item;
        public ItemData ReadItemData() => _itemData;

        public void RenderModel()
        {

            renderModel.Render();
        }

        public void RenderModel(ItemModel itemModel)
        {
            renderModel = new RenderItemModel(this.transform, itemModel);
            renderModel.Render();
        }

        public void SetPositionRender(IProviderPosition providerPosition)
        {
            setPosition = new EquipToHandRight(this.transform, providerPosition);
            setPosition.SetPosition();
        }
    }
}
