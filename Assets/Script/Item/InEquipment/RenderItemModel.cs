using UnityEngine;
namespace Item.InEquipment
{
    using Information;
    internal class RenderItemModel : IRenderModel
    {
        ItemModel _itemModel;
        Transform _containModel;
        public RenderItemModel(Transform containModel, Item.Information.ItemModel itemModel)
        {
            _containModel = containModel;
            _itemModel = itemModel;
        }
        public void Render()
        {
            var model = MonoBehaviour.Instantiate(_itemModel.Prefab, _containModel);
            Transform transform = model.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localEulerAngles = Vector3.zero;
            transform.localScale = Vector3.one;

        }
    }
}
