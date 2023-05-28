namespace AnimatorContent
{
    using UnityEngine;
    using Item.ItemGameData;
    [System.Serializable]
    internal class AnimatorMovementFactory
    {
        private Animator _animator;
        [SerializeField] RuntimeAnimatorController _syctheMovement;

        public AnimatorMovementFactory(Animator animator)
        {
            _animator = animator;
        }

        public MovementController Factory(WeaponData weaponData)
        {
            switch(weaponData)
            {
                case ScytheData:
                    return new MovementController(_animator, _syctheMovement);
                default:
                    return null;
            }
        }
    }
}
