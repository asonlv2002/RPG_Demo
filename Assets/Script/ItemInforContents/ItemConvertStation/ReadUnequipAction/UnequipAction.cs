namespace ItemInforContents
{
    internal class UnequipAction : ButtonAction
    {
        public override void Init(ItemInforCores itemInforCores)
        {
            UnityEngine.Debug.Log("Init Unequip");
            base.Init(itemInforCores);
            var equipmentReader = ItemInforCores.GetContentComponent<ReadUnequipFormEquipment>();
            AddConvertItemStation(equipmentReader);
            var inventoryReader = ItemInforCores.GetContentComponent<ReadUnequipFormInventory>();
            AddConvertItemStation(inventoryReader);
        }
    }
}
