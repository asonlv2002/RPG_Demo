using UnityEngine;
namespace Item.InEquipment
{
    [System.Serializable]
    internal abstract class WeaponBehaviour
    {
        [field : SerializeField] public RuntimeAnimatorController AnimaotrController { get; protected set; }
        public StateContent.BaseState BigRootState { get; protected set; }
    }
}
