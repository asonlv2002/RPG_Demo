namespace UIEquipmentContents
{
    using Achitecture;
    using UnityEngine;
    internal class UIEquipment : UIEquipmentCores
    {
        [SerializeField] ButtonEquipmentGroup buttonEquipments;
        [SerializeField] EquipmentOpenItemInfor _openInfor;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            _openInfor = new EquipmentOpenItemInfor(this);
            AddContentComponent(_openInfor);
            AddContentComponent(buttonEquipments);
            AddContentComponent(new ReadConvertEquipItem(this));
        }


    }
}
