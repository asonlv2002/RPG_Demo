namespace ItemInforContents
{
    using Item.ItemGameData;
    using UnityEngine.Events;
    using System.Collections.Generic;
    internal interface IOpenItemInformation
    {
        List<ISubOpenItemInformation> SubOpenItemInformations { get; }

        void AddEventOpen(ISubOpenItemInformation subOpenItem);

        void RemoveEventOpen(ISubOpenItemInformation subOpenItem);

        void OnOpenInformation(ItemData itemData);
    }
}
