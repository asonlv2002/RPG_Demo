namespace SignItemContents
{
    using Achitecture;
    using UnityEngine;
    internal class SignItem : SignItemCores
    {
        [SerializeField] OpenCloseSignItems openCloseSignItems;
        [SerializeField] SignItemStore _signItemSore;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(openCloseSignItems);
            AddContentComponent(_signItemSore);
        }
    }
}
