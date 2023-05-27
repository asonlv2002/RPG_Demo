namespace InputModify
{
    using Item.ItemGameData;
    internal class InputAttackFactory
    {
        public InputAttack InputAttack { get; private set; }
        public InputAttackFactory(WeaponData data)
        {
            InputAttack = Factory(data);
        }

        InputAttack Factory(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    return new InputAttackScytheContent();
                default:
                    return null;
            }
        }
    }
}
