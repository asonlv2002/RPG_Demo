using Item.ItemGameData;

namespace ItemInforContents
{
    internal class OpemItemInforOnClickItem : ISubOpenItemInformation
    {
        OpenCloseItemInfor OpenItemInfor;
        public OpemItemInforOnClickItem(OpenCloseItemInfor openCloseItemInfor)
        {
            OpenItemInfor = openCloseItemInfor;
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            if (!OpenItemInfor.IsOpen) OpenItemInfor.OpenAction();
        }
    }
}
