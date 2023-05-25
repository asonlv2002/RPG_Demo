using UnityEngine;
using Item.InEquipment;
using Item.ItemGameData;
using Item;
using Entities;

namespace Equipments
{
    internal class PlayerEquipment : Entities.BranchContent
    {
        [SerializeField] WeaponEquipmentManager _weaponEquipment; 
        [SerializeField] StoreEquipmentPosition equipmentPositions;
        IEquipWeaponNotify _equipWeaponNotify;
        public override void InitMainContent(PlayerRootContent mainContent)
        {
            base.InitMainContent(mainContent);
            _equipWeaponNotify = new EquipWeaponChannel(MainContent);
            _weaponEquipment = new WeaponEquipmentManager(equipmentPositions, _equipWeaponNotify);
        }
        private void OnTriggerEnter(Collider other)
        {
            var equipment = other.gameObject;
            var equipmentData = equipment.GetComponent<IItem>();
            EquipEquipment(equipmentData);
        }

        void EquipEquipment(IItem equipment)
        {
            if (equipment == null) return;
            IEquipmentManager equipmentManager = EquipmentManagerProxy(equipment);
            equipmentManager.Equip(equipment);
        }

        IEquipmentManager EquipmentManagerProxy(IItem itemData)
        {
            switch (itemData.ItemData)
            {
                case WeaponData:
                    return _weaponEquipment;
                default : 
                    return null;
            }
        }
    }
}
