using Item.Type;

namespace Item.InEquipment
{
    internal class WeaponBeHaviourFactory
    {
        public WeaponBehaviour CreateWeaponData(ITypeWeapon typeWeapon)
        {
            switch(typeWeapon)
            {
                case IBow:
                    return new ScytheBehaviour();
                case IScythe:
                    return new ScytheBehaviour();
                default:
                    return null;
            }
        }
    }
}
