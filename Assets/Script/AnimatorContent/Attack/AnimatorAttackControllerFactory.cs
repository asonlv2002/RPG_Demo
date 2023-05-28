namespace AnimatorContent
{
    using UnityEngine;
    using Item.ItemGameData;
    [System.Serializable]
    internal class AimatorContentByWeaponFactory
    {
        [SerializeField] RuntimeAnimatorController AttackScytheController;
        [SerializeField] RuntimeAnimatorController AttackBowController;

        Animator _animator;
        public AimatorContentByWeaponFactory(Animator animator)
        {
            _animator = animator;
        }
        public AttackController Factory(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    return new AttackController(_animator, AttackScytheController);
                case BowData:
                    return new AttackController(_animator, AttackBowController);
                default: 
                    return null;
            }
        }

    }
}
