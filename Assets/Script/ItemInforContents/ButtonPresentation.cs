namespace ItemInforContents 
{
    using Item.ItemGameData;
    using UnityEngine;
    [System.Serializable]
    internal class ButtonPresentation : ItemInforComponent, ISubOpenItemInformation
    {
        [SerializeField] ItemInforCores ItemInforCores;
        [field : SerializeField] public EquipAction Equip { get; private set; }
        [field : SerializeField] public UnequipAction Unequip { get; private set; }
        [field : SerializeField] public UseAction UseAction { get; private set; }

        public override void OnAddComponent()
        {
            Init(ItemInforCores);
        }

        public void Init(ItemInforCores itemInforCores)
        {
            ItemInforCores = itemInforCores;
            Equip.Init(ItemInforCores);
            Unequip.Init(ItemInforCores);
        }

        public void OnOpenItemInformation(ItemData itemData)
        {
            
        }
    }
}
