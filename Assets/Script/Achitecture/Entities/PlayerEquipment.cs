using UnityEngine;
using Item.InEquipment;
using Item.InWorldSpace;
using Item.ItemGameData;
namespace Equipments
{
    internal class PlayerEquipment : Entities.BranchContent
    {
        [field : SerializeField] public WeaponEquipment WeaponEquipment { get; private set; }
        private void OnTriggerEnter(Collider other)
        {
            var equipment = other.GetComponent<ItemWorldController>();
            EquipEquipment(equipment);
        }

        void EquipEquipment(ItemWorldController equipment)
        {
            if (equipment == null) return;

            WeaponEquipment.EquipWeaponInWorldSpace(new ItemAdapter.WeaponProviderFormWorld(equipment));

            Destroy(equipment.gameObject);
        }
    }
}
