
using Item.ItemGameData;
using UnityEngine;
using ItemInforContents;
using System.Collections.Generic;

namespace InventoryContents
{
    [System.Serializable]
    internal class InventoryOpenItemInfor : InventoryComponent,IOpenItemInformation
    {
        [SerializeField] InventoryCore _inventorCore;
        public List<ISubOpenItemInformation> SubOpenItemInformations { get; private set; } = new List<ISubOpenItemInformation>();
        public override void OnAddComponent()
        {
            Init(_inventorCore);
        }

        public void AddEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Add(subOpenItem);
        }

        public void OnOpenInformation(ItemData itemData)
        {
            //_inventorCore.MainCores.GetCore<ItemInforCores>().GetContentComponent<OpenCloseItemInfor>().TransfomPresentation.OnOpen();
            //Debug.Log(SubOpenItemInformations.Count);
            foreach (var eventOpen in SubOpenItemInformations)
            {
                eventOpen.OnOpenItemInformation(itemData);
            }
        }

        public void RemoveEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Remove(subOpenItem);
        }

        void Init(InventoryCore inventoryCore)
        {
            var itemOpen = inventoryCore.MainCores.GetCore<ItemInforCores>();
            AddEventOpen(new OpemItemInforOnClickItem(itemOpen.GetContentComponent<OpenCloseItemInfor>()));
            AddEventOpen(itemOpen.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemOpen.GetContentComponent<ItemEffectsPresentation>());
            AddEventOpen(new OpenItemInformationInInventory(itemOpen.GetContentComponent<ButtonPresentation>()));
        }
    }
}
