namespace QuickUseItemContents
{
    using Achitecture;
    using UnityEngine;
    internal class QuickUse : QuickUseCores
    {
        [SerializeField] QuickItemStore quickItemStore;

        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(quickItemStore);
        }
    }
}
