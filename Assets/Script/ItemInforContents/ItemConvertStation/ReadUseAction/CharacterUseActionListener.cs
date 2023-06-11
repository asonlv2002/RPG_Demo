using Achitecture;
using EquipmentContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class CharacterUseActionListener: IConvertItemStationListener
    {
        UseConsumableItem _useConsumable;
        public void OnConverItemStation(ItemData itemData)
        {
            LateInit();
            _useConsumable.UseItem(itemData);
        }

        void LateInit()
        {
            if(_useConsumable == null)
            {
                _useConsumable = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().GetContentComponent<UseConsumableItem>();
            }
        }
    }
}
