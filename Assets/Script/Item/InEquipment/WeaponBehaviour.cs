using UnityEngine;
namespace Item.InEquipment
{
    [System.Serializable]
    internal abstract class WeaponBehaviour
    {
        [field : SerializeField] public RuntimeAnimatorController AnimaotrController { get; protected set; }
        public StateMachine.PlayerBaseState BigRootState { get; protected set; }
    }
}
