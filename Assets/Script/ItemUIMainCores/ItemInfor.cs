namespace ItemInforContents
{
    using Achitecture;
    using UnityEngine;
    internal class ItemInfor : ItemInforCores
    {
        [SerializeField] OpenCloseItemInfor _openCloseItemInfor;
        [SerializeField] ItemInformationPresentation _informationPresentation;
        [SerializeField] ItemEffectsPresentation _effectsPresentation;
        [SerializeField] ButtonPresentation _buttonOnInfor;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            Debug.Log(_openCloseItemInfor);
            AddContentComponent(_openCloseItemInfor);
            AddContentComponent(_informationPresentation);
            AddContentComponent(_effectsPresentation);
            AddContentComponent(_buttonOnInfor);

            AddContentComponent(new EquipListeners(this));
            AddContentComponent(new UnequipListeners(this));

            this.gameObject.SetActive(false);
        }
    }
}
