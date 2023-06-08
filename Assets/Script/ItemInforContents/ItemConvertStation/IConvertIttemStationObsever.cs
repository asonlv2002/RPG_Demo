using Item.ItemGameData;
using System.Collections.Generic;

namespace ItemInforContents
{
    internal interface IConvertIttemStationObsever
    {
        List<IConvertItemStationSub> ConvertItemStationSubs { get; }
        void AddConvertItemStation(IConvertItemStationSub item);
        void SubConvertItemStation(IConvertItemStationSub item);
        void OnConverStationItem(ItemData itemData);
    }
}
