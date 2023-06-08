using UIEquipmentContents;

namespace ItemInforContents
{
    internal class EquipAction : ButtonAction
    {
        public override void Init(ItemInforCores itemInforCores)
        {
            UnityEngine.Debug.Log("Init Equip");
            base.Init(itemInforCores);
            var equipmentReader = ItemInforCores.GetContentComponent<ReadEquipItemInEquipment>();
            AddConvertItemStation(equipmentReader);
            var inventoryReader = ItemInforCores.GetContentComponent<ReadEquipItemInInventory>();
            AddConvertItemStation(inventoryReader);
        }
    }
}
