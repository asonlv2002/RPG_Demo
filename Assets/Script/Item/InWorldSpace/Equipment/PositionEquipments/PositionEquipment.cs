using UnityEngine;
namespace Item.Information
{
    [System.Serializable]
    internal class PositionEquipment
    {
        [field: SerializeField] public Transform EquipmentTransform { get; private set; }

        public PositionEquipment(Transform equipmentTransform)
        {
            EquipmentTransform = equipmentTransform;
        }

        public virtual void SetPositionEquipment(Transform transformParent)
        {
            EquipmentTransform.SetParent(transformParent);
            ResetLocationTransform();
        }
        public virtual Transform GetPostionEquipment() => EquipmentTransform.parent;

        protected virtual void ResetLocationTransform()
        {
            EquipmentTransform.localPosition = Vector3.zero;
            EquipmentTransform.localRotation = Quaternion.identity;
            EquipmentTransform.localEulerAngles = Vector3.forward * 90f;
        }
    }
}