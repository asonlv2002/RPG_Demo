using UnityEngine;
namespace Item.InEquipment
{
    using Information;

    internal abstract class RenderWeaponOnHand : IItemRender
    {
        protected Transform positionEquip;
        protected ItemModel Model;
        protected Transform ModelTransForm;

        public RenderWeaponOnHand(Transform providerPosition, ItemModel model)
        {
            positionEquip = providerPosition;
            Model = model;
            RenderModel();
        }

        public virtual void RenderModel()
        {

        }

        public void SetTransForm(Transform transform)
        {
            ModelTransForm.SetParent(transform);
            ResetTransform(ModelTransForm);


        }

        protected virtual void ResetTransform(Transform modelTransform)
        {
            modelTransform.localPosition = new Vector3(0.04f, -0.06f, 0.175f);
            modelTransform.localRotation = Quaternion.identity;
            modelTransform.localEulerAngles = new Vector3(-3.5f, -90f, 90f);
        }
    }
}