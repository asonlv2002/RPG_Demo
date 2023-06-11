
using Item;
using UnityEngine.Events;
using UnityEngine;

namespace EquipmentContents
{
    internal class TriggerItems : EquipmentComponent
    {
        public UnityAction<IItem> OnEnterTrigerItem;
        public UnityAction<IItem> OnExitTriggerItem;

        public void EnterTriggerItem(GameObject objectTrigger)
        {
            var equipmentData = objectTrigger.GetComponent<IItem>();
            if (equipmentData != null) OnEnterTrigerItem.Invoke(equipmentData);
        }
        public void ExitTriggerItem(GameObject objectTrigger)
        {
            var equipmentData = objectTrigger.GetComponent<IItem>();
            if (equipmentData != null) OnExitTriggerItem.Invoke(equipmentData);
        }
    }
}
