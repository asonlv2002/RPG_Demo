namespace AnimatorContent
{
    using Item.ItemGameData;
    internal class AnimationAttackParameterFactory
    { 
        public AnimationAttackParameter Factory(WeaponData weaponData)
        {
            switch (weaponData)
            {
                case ScytheData:
                    return new ScytheAttackParameter();
                default:
                return null;
            }
        }
    }
}
