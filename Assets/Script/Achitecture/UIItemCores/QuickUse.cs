namespace QuickUseItemContents
{
    using Achitecture;
    using UnityEngine;
    internal class QuickUse : QuickUseCores
    {
        [SerializeField] OpenCloseQuickUseItem _openCloseQuickItem;
        [SerializeField] QuickItemStore quickItemStore;

        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_openCloseQuickItem);
            AddContentComponent(quickItemStore);

            this.gameObject.SetActive(false);
            _openCloseQuickItem.CloseAction();
        }
    }
}
