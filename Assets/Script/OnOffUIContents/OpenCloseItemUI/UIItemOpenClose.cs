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
            Debug.Log(ItemInfor);
            Debug.Log(Equipment);
            Debug.Log(Inventory);
            Inventory.OnOpenAction = Equipment.OnOpenAction  = OpenUI;
            Inventory.OnCloseAction = Equipment.OnCloseAction  = CloseUI;
        }

        void OpenUI()
        {
            Debug.Log("Open");
        }

        void CloseUI()
        {
            Debug.Log("Close");
            Debug.Log(Equipment.IsOpen);
            Debug.Log(Inventory.IsOpen);
            if (!Equipment.IsOpen && !Inventory.IsOpen) ItemInfor.CloseAction();
        }
    }
}
