
namespace Item
{
    using Information;
    using UnityEngine;
    internal class RenderInEnviroment : IItemRender
    {
        Transform _transform;
        ItemModel _model;
        public RenderInEnviroment(Transform transformInEnviroment, ItemModel model)
        {
            _transform = transformInEnviroment;
            _model = model;
        }

        public void RenderModel()
        {
            var Item = MonoBehaviour.Instantiate(_model.Prefab, _transform);
            Item.transform.localEulerAngles = Vector3.zero;
            Item.transform.localPosition = Vector3.zero;
            Item.transform.localRotation = Quaternion.identity;
        }

        public void SetTransForm(Transform transform)
        {
            throw new System.NotImplementedException();
        }
    }
}
