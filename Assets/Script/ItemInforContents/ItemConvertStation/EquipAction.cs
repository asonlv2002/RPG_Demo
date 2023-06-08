using UIEquipmentContents;

namespace ItemInforContents
{
    internal class EquipAction : ButtonAction
    {
        public override void Init(ItemInforCores itemInforCores)
        {
            base.Init(itemInforCores);
            var equipmentReader = ItemInforCores.MainCores.GetCore<UIEquipmentCores>().GetContentComponent<ReadConvertEquipItem>();
            AddConvertItemStation(equipmentReader);
        }

        protected override void OnClickEffect()
        {
            base.OnClickEffect();
        }
    }
}
