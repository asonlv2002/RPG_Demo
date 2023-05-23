using UnityEngine;

namespace Item.InEquipment
{
    [System.Serializable]
    internal class StoreEquipmentPosition : IWeaponEquipPosition
    {
        [SerializeField] Transform _handLeft;
        [SerializeField] Transform _handRight;

        public Transform HandLeft()
        {
            return _handLeft;
        }

        public Transform HandRight()
        {
            return _handRight;
        }
    }
}
