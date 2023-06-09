namespace ItemInforContents
{
    internal class UnequipListeners : ListenerContain
    {
        private UnequipAction _unequipAction;
        public UnequipListeners(ItemInforCores _core) : base(_core)
        {
            Signer = _unequipAction = InforCores.GetContentComponent<ButtonPresentation>().Unequip;
            AddListener(new EquipmentUnequipListener(InforCores));
            AddListener(new InventoryUnequipListener(InforCores));
            AddListener(new CharacterUnequipListener());
        }
    }
}
