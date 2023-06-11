using UnityEngine;
using Item.InEquipment;
using Item.ItemGameData;
using Item;
using Achitecture;

namespace EquipmentContents
{

    internal class PlayerEquipment : EquipmentCore
    {

        [SerializeField] WeaponEquipmentManager _weaponEquipment; 
        [SerializeField] StoreEquipmentPosition equipmentPositions;
        [SerializeField] TriggerItems _triggerItems;
        public EquipWeaponChannel channel;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            channel = new EquipWeaponChannel(MainCores);
            AddContentComponent(_weaponEquipment);
            AddContentComponent(_triggerItems);

        }
        private void OnTriggerEnter(Collider other)
        {
            _triggerItems.EnterTriggerItem(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _triggerItems.ExitTriggerItem(other.gameObject);
        }

        public override void EquiEquipment(ItemData equipment)
        {
            _weaponEquipment.AddWepon(equipment);
        }

        public override void UnequipItem(ItemData equipment)
        {
            _weaponEquipment.RemoveWeapon();
        }
    }
}
