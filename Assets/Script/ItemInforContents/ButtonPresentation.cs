namespace ItemInforContents 
{
    using Item.ItemGameData;
    using UnityEngine;
    [System.Serializable]
    internal class ButtonPresentation : ItemInforComponent, ISubOpenItemInformation
    {
        [SerializeField] ItemInforCores ItemInforCores;
        [field : SerializeField] public EquipAction EquipAction { get; private set; }
        [field : SerializeField] public UseAction UseAction { get; private set; }

        public void Init(ItemInforCores itemInforCores)
        {
            ItemInforCores = itemInforCores;
            EquipAction.Init(ItemInforCores);
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            
        }
    }
}
