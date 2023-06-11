
using Item;
using UnityEngine.Events;
using UnityEngine;

namespace EquipmentContents
{
    [System.Serializable]
    internal class TriggerItems : EquipmentComponent
    {
        [SerializeField] public UnityAction<IItem> OnEnterTriggerItem;
        [SerializeField] public UnityAction<IItem> OnExitTriggerItem;

        public void EnterTriggerItem(GameObject objectTrigger)
        {
            var equipmentData = objectTrigger.GetComponent<IItem>();
            if (equipmentData != null) OnEnterTriggerItem.Invoke(equipmentData);
        }
        public void ExitTriggerItem(GameObject objectTrigger)
        {
            var equipmentData = objectTrigger.GetComponent<IItem>();
            if (equipmentData != null) OnExitTriggerItem.Invoke(equipmentData);
        }
    }
}
