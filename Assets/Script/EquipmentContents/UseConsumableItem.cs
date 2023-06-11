namespace EquipmentContents
{
    using Item.ItemGameData;
    internal class UseConsumableItem : EquipmentComponent
    {
        EquipmentCore _equipmentCore;

        public UseConsumableItem(EquipmentCore equipmentCore)
        {
            _equipmentCore = equipmentCore;
        }

        public void UseItem(ItemData itemData)
        {
            foreach(var effect in itemData.Effects.ItemEffects)
            {
                effect.EnableEffect(_equipmentCore.MainCores);
            }
        }
    }
}
