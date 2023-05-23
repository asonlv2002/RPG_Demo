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
            modelTransform.localPosition = Vector3.zero;
            modelTransform.localRotation = Quaternion.identity;
            modelTransform.localEulerAngles = Vector3.zero; 
        }
    }
}