using ItemInforContents;
using InventoryContents;
using UIEquipmentContents;

namespace OnOffUIContents
{
    using UnityEngine;
    internal class UIItemOpenClose : OnpenCloseUIComponent
    {
        OpenCloseUICores OpenCloseCore;
        public IOpenClose ItemInfor;
        public IOpenClose Inventory;
        public IOpenClose Equipment;
        public UIItemOpenClose(OpenCloseUICores openCloseCore)
        {
            OpenCloseCore = openCloseCore;
        }

        public override void OnAddComponent()
        {
            Inventory = OpenCloseCore.MainCores.GetCore<InventoryCore>().GetContentComponent<OpenCloseInventory>();
            Equipment = OpenCloseCore.MainCores.GetCore<UIEquipmentCores>().GetContentComponent<OpenCloseUIEquipment>();
            ItemInfor = OpenCloseCore.MainCores.GetCore<ItemInforCores>().GetContentComponent<OpenCloseItemInfor>();
            Inventory.OnOpenAction = Equipment.OnOpenAction  = OpenUI;
            Inventory.OnCloseAction = Equipment.OnCloseAction  = CloseUI;
        }

        void OpenUI()
        {

        }

        void CloseUI()
        {
            if (!Equipment.IsOpen && !Inventory.IsOpen) ItemInfor.CloseAction();
        }
    }
}
