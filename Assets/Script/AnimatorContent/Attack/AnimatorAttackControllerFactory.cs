namespace AnimatorContent
{
    using UnityEngine;
    using Item.ItemGameData;
    [System.Serializable]
    internal class AnimatorAttackControllerFactory
    {
        [SerializeField] RuntimeAnimatorController AttackScytheController;
        [SerializeField] RuntimeAnimatorController AttackBowController;

        Animator _animator;
        public AnimatorAttackControllerFactory(Animator animator)
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
