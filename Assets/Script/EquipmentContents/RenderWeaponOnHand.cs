using UnityEngine;
namespace Item.InEquipment
{
    using Information;

    internal abstract class RenderWeaponOnHand : IItemRender
    {
        protected IWeaponEquipPosition ProviderPosition;
        protected ItemModel Model;

        public RenderWeaponOnHand(IProviderPosition providerPosition, ItemModel model)
        {
            ProviderPosition = providerPosition as IWeaponEquipPosition;
            Model = model;
        }

        public abstract void RenderModel();

        protected virtual void ResetTransform(Transform modelTransform)
        {
            modelTransform.localPosition = new Vector3(0.04f, -0.06f, 0.175f);
            modelTransform.localRotation = Quaternion.identity;
            modelTransform.localEulerAngles = new Vector3(-3.5f, -90f, 90f);
        }
    }
}