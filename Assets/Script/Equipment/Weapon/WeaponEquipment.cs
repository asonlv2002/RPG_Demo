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
            if (postionEquipment is HandRightEquipment)
            {
                postionEquipment.SetPositionEquipment(HandRight);
            }
            else
            {
                postionEquipment.SetPositionEquipment(HandLeft);
            }

            switch (postionEquipment)
            {
                case HandRightEquipment:
                    postionEquipment.SetPositionEquipment(HandRight);
                    break;

            }
        }
    }
}
