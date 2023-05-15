using UnityEngine;
using Equipments.PositionEquipments;

namespace Equipments.Weapon
{
    [System.Serializable]
    internal class WeaponEquipment
    {
        [field: SerializeField] public Transform HandLeft { get; private set; }
        [field: SerializeField] public Transform HandRight { get; private set; }

        WeaponInWorldSpace curentWeaponEquipment;

        public void EquipWeapon(EquipmentWorldSpace weapon)
        {
            curentWeaponEquipment = weapon as WeaponInWorldSpace;
            var postionEquipment = curentWeaponEquipment.PositionEquipment;
            switch (postionEquipment)
            {
                case HandRightEquipment:
                    postionEquipment.SetPositionEquipment(HandRight);
                    break;

            }
        }

        public void UnequipWeapon()
        {
            var postionEquipment = curentWeaponEquipment.PositionEquipment;
            postionEquipment.SetPositionEquipment(null);
        }
    }
}
