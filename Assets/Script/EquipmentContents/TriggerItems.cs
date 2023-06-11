
using Item;
using UnityEngine.Events;
using UnityEngine;
using Item.InEnviroment;

namespace EquipmentContents
{
    [System.Serializable]
    internal class TriggerItems : EquipmentComponent
    {
        public UnityAction<ItemInEnviroment> OnEnterTriggerItem;
        public UnityAction<ItemInEnviroment> OnExitTriggerItem;

        public void EnterTriggerItem(GameObject objectTrigger)
        {
            var item = objectTrigger.GetComponent<ItemInEnviroment>();
            if (item != null) OnEnterTriggerItem.Invoke(item);
        }
        public void ExitTriggerItem(GameObject objectTrigger)
        {
            var item = objectTrigger.GetComponent<ItemInEnviroment>();
            if (item != null) OnExitTriggerItem.Invoke(item);
        }
    }
}
