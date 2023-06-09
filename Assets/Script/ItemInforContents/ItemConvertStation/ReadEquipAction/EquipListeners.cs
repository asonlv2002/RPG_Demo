
namespace ItemInforContents
{
    internal class EquipListeners : ListenerContain
    {
        private EquipAction _equipAction;
        public EquipListeners(ItemInforCores itemInforCores) : base(itemInforCores)
        {
            Signer = _equipAction = InforCores.GetContentComponent<ButtonPresentation>().Equip;

            AddListener(new CharacterEquipListener());
            AddListener(new UIEquipmentEquipListener(InforCores));
            AddListener(new InventoryEquipListener(InforCores));
        }

    }
}
