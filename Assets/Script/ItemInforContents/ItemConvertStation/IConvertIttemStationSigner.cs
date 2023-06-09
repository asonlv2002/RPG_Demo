using Item.ItemGameData;
using System.Collections.Generic;

namespace ItemInforContents
{
    internal interface IConvertIttemStationSigner
    {
        List<IConvertItemStationListener> ConvertItemStationSubs { get; }
        void AddConvertItemStation(IConvertItemStationListener item);
        void RemoveConvertItemStation(IConvertItemStationListener item);
        void OnConverStationItem(ItemData itemData);
    }
}
