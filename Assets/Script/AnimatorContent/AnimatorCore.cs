namespace AnimatorContent
{
    using UnityEngine;
    internal abstract class AnimatorCore : Achitecture.CoreContain<AnimatorComponent>
    {
        [field: SerializeField] public Animator Animator { get; private set; }
    }
}
