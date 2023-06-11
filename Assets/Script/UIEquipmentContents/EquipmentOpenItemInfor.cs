using Item.ItemGameData;
using ItemInforContents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIEquipmentContents
{
    [System.Serializable]
    internal class EquipmentOpenItemInfor : UIEquipmentComponent, IOpenItemInformation
    {
        [SerializeField] UIEquipmentCores _uiEquipmentCores;
        public List<ISubOpenItemInformation> SubOpenItemInformations { get; private set; }

        public override void OnAddComponent()
        {
            SubOpenItemInformations = new List<ISubOpenItemInformation>();
            Init();
        }

        public void AddEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Add(subOpenItem);

        }
        public void OnOpenInformation(ItemData itemData)
        {
            foreach (var sub in SubOpenItemInformations)
            {
                sub.OnOpenItemInformation(itemData);
            }
        }

        public void RemoveEventOpen(ISubOpenItemInformation subOpenItem)
        {
            SubOpenItemInformations.Remove(subOpenItem);
        }

        public void Init()
        {
            var itemInfor = _uiEquipmentCores.MainCores.GetCore<ItemInforCores>();
            AddEventOpen(new OpemItemInforOnClickItem(itemInfor.GetContentComponent<OpenCloseItemInfor>()));
            AddEventOpen(itemInfor.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemInfor.GetContentComponent<ItemEffectsPresentation>());
            AddEventOpen(new OpenItemInformationInEquipment(itemInfor.GetContentComponent<ButtonPresentation>()));
        }
    }
}
