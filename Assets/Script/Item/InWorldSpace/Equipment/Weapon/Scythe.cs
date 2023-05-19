using Item.Information;
namespace Item.InWorldSpace
{
    internal class Scythe : WeaponInWorldSpace
    {
        private void Awake()
        {
            this.positionEquip = new HandRightEquipment(this.transform);  
        }
    }
}
