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
        [SerializeField] PositionEquipStore _positionEquipment;

        [SerializeField] TriggerItems _triggerItems;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_triggerItems);
            AddContentComponent(new UseConsumableItem(this));
            InitEquipment();
        }
        private void OnTriggerEnter(Collider other)
        {
            _triggerItems.EnterTriggerItem(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _triggerItems.ExitTriggerItem(other.gameObject);
        }

        void InitEquipment()
        {
            AddContentComponent(_positionEquipment);
            AddContentComponent(_weaponEquipment);
            AddContentComponent(new EquipEquipmentControl(this));
        }
    }
}
