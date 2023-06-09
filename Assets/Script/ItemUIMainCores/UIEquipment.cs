namespace UIEquipmentContents
{
    using Achitecture;
    using UnityEngine;
    internal class UIEquipment : UIEquipmentCores
    {
        [SerializeField] OpenCloseUIEquipment _openCloseUIEquipment;
        [SerializeField] ButtonEquipmentGroup buttonEquipments;
        [SerializeField] EquipmentOpenItemInfor _openInfor;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_openCloseUIEquipment);
            AddContentComponent(_openInfor);
            //StartCoroutine(_openInfor.Init());
            AddContentComponent(buttonEquipments);
            this.gameObject.SetActive(false);
        }
    }
}
