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
        public EquipWeaponChannel channel;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            channel = new EquipWeaponChannel(MainCores);

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
            equipmentManager.AddWepon(equipment);
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
