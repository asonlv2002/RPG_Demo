namespace ItemInforContents
{
    internal class AddQuickUseListener : ListenerContain
    {
        AddQuickUseAction AddQuickUse;
        public AddQuickUseListener(ItemInforCores _core) : base(_core)
        {
            Signer = AddQuickUse = InforCores.GetContentComponent<ButtonPresentation>().AddQuickUseAction;
            AddListener(new InventoryAddQuickUseListener(_core));
        }
    }
}
