namespace AnimatorContent
{
    using UnityEngine;
    using Item.ItemGameData;
    [System.Serializable]
    internal class MovementAnimatorController : AnimatorComponent
    {
        [field: SerializeField] public RuntimeAnimatorController Scythe { get; private set; }
        [field: SerializeField] public RuntimeAnimatorController Bow { get; private set; }
    }
}
