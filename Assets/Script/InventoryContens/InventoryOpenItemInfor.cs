
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
        public List<ISubOpenItemInformation> SubOpenItemInformations { get; private set; }
        public override void OnAddComponent()
        {
            SubOpenItemInformations = new List<ISubOpenItemInformation>();
            Init(_inventorCore);
        }

        public void AddEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Add(subOpenItem);
        }

        public void OnOpenInformation(ItemData itemData)
        {
            foreach(var eventOpen in SubOpenItemInformations)
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
            AddEventOpen(itemOpen.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemOpen.GetContentComponent<ItemEffectsPresentation>());
            var buttonAction = itemOpen.GetContentComponent<ButtonPresentation>();
            AddEventOpen(new OpenItemInformationInInventory(buttonAction));
        }
    }
}
