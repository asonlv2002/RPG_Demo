using UnityEngine;
namespace Item.InEquipment
{
    using Information;

    internal class RenderWeaponOnHand : IItemRender
    {
        protected Transform positionEquip;
        protected ItemModel Model;
        protected Transform ModelTransForm;

        public RenderWeaponOnHand(Transform providerPosition, ItemModel model)
        {
            positionEquip = providerPosition;
            Model = model;
            var weapon = MonoBehaviour.Instantiate(Model.Prefab, positionEquip);
            ModelTransForm = weapon.transform;
            OnEquipWeapon();
        }

        public virtual void OnEquipWeapon()
        {
            ModelTransForm.SetParent(positionEquip);
            ResetTransform(ModelTransForm);
        }

        public void SetTransForm(Transform transform)
        {
            ModelTransForm.SetParent(transform);
            ResetTransform(ModelTransForm);
        }

        protected virtual void ResetTransform(Transform modelTransform)
        {
            modelTransform.localPosition = Model.PositionEquip;
            modelTransform.localRotation = Quaternion.identity;
            modelTransform.localEulerAngles = Model.RotationEquip;
        }
    }
}