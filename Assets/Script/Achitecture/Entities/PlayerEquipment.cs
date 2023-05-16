using UnityEngine;
using Equipments.Weapon;
namespace Equipments
{
    internal class PlayerEquipment : Entities.BranchContent
    {
        [field : SerializeField] public WeaponEquipment WeaponEquipment { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            var equipment = other.GetComponent<EquipmentWorldSpace>();
            if(equipment)
            {
                Debug.Log("HelloWorld");
                WeaponEquipment.EquipWeapon(equipment);
            }
        }
    }
}
