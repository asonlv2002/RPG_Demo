using Achitecture;

namespace OnOffUIContents
{
    internal class UIOpenClose : OpenCloseUICores
    {
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(new UIItemOpenClose(this));
        }
    }
}
