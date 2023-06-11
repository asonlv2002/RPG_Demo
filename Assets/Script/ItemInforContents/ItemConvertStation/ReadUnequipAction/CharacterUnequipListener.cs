using Achitecture;
using EquipmentContents;
using Item.ItemGameData;

namespace ItemInforContents
{
    internal class CharacterUnequipListener : IConvertItemStationListener
    {
        EquipEquipmentControl _equipEquipment;
        public void OnConverItemStation(ItemData itemData)
        {
            LateInit();
            _equipEquipment.UnequipEquipment(itemData);
        }

        void LateInit()
        {
            if (_equipEquipment == null)
            {
                _equipEquipment = CharacterSingletonIntance.Instance.MainCore.GetCore<EquipmentCore>().GetContentComponent<EquipEquipmentControl>();
            }
        }
    }
}
