namespace ItemInforContents
{
    using Achitecture;
    using UnityEngine;
    internal class ItemInfor : ItemInforCores
    {
        [SerializeField] ItemInformationPresentation _informationPresentation;
        [SerializeField] ItemEffectsPresentation _effectsPresentation;
        [SerializeField] ButtonPresentation _buttonOnInfor;
        public override void InitMainCore(MainCores mainCores)
        {
            base.InitMainCore(mainCores);
            AddContentComponent(_informationPresentation);
            AddContentComponent(_effectsPresentation);
            _buttonOnInfor.Init(this);
            AddContentComponent(_buttonOnInfor);

            AddContentComponent(new EquipListeners(this));
            AddContentComponent(new UnequipListeners(this));
        }
    }
}
