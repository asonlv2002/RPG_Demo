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
            ItemInforCores itemInfor = _uiEquipmentCores.MainCores.GetCore<ItemInforCores>();
            AddEventOpen(itemInfor.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemInfor.GetContentComponent<ItemEffectsPresentation>());
            var buttonAction = itemInfor.GetContentComponent<ButtonPresentation>();
            AddEventOpen(new OpenItemInformationInEquipment(buttonAction));
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

        public IEnumerator Init()
        {
            ItemInforCores itemInfor = null;
            yield return new WaitUntil(() => GetItemInfor(out itemInfor));
            AddEventOpen(itemInfor.GetContentComponent<ItemInformationPresentation>());
            AddEventOpen(itemInfor.GetContentComponent<ItemEffectsPresentation>());
            var buttonAction = itemInfor.GetContentComponent<ButtonPresentation>();
            AddEventOpen(new OpenItemInformationInEquipment(buttonAction));
        }

        bool GetItemInfor(out ItemInforCores itemInfor)
        {
            return (itemInfor = _uiEquipmentCores.MainCores.GetCore<ItemInforCores>()) != null;
        }
    }
}
