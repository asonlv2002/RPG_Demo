
namespace ItemInforContents
{
    internal class UseListener : ListenerContain
    {
        UseAction _useAction;
        public UseListener(ItemInforCores _core) : base(_core)
        {
            Signer = _useAction = InforCores.GetContentComponent<ButtonPresentation>().UseAction;
            AddListener(new CharacterUseActionListener());
            AddListener(new InventoryUseActionListener(InforCores));
        }
    }
}
