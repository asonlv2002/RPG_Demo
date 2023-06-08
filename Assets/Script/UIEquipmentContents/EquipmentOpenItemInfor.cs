using Item.ItemGameData;
using ItemInforContents;
using System.Collections.Generic;
using UnityEngine;
namespace UIEquipmentContents
{
    [System.Serializable]
    internal class EquipmentOpenItemInfor : UIEquipmentComponent, IOpenItemInformation
    {
        [SerializeField] UIEquipmentCores _uiEquipmentCores;
        public List<ISubOpenItemInformation> SubOpenItemInformations { get; private set; }

        public EquipmentOpenItemInfor(UIEquipmentCores uIEquipmentCores)
        {
            SubOpenItemInformations = new List<ISubOpenItemInformation>();
            _uiEquipmentCores = uIEquipmentCores;
        }

        public void AddEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Add(subOpenItem);
        }

        public void OnOpenInformation(ItemData itemData)
        {
            foreach(var sub in SubOpenItemInformations)
            {
                sub.OnOpenItemInformation(itemData);
            }
        }

        public void RemoveEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Remove(subOpenItem);
        }

        public void Init(UIEquipmentCores uIEquipmentCores)
        {
            var itemOpen = uIEquipmentCores.MainCores.GetCore<ItemInforCores>();
            AddEventOpen(itemOpen.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemOpen.GetContentComponent<ItemEffectsPresentation>());
            var buttonAction = itemOpen.GetContentComponent<ButtonPresentation>();
            AddEventOpen(new OpenItemInformationInEquipment(buttonAction));
        }
    }
}
