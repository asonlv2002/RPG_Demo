namespace AnimatorContent
{
    internal interface IAnimatorContent : Achitecture.IContent<AnimatorComponent>
    {
        UnityEngine.Animator Animator { get; }
    }
}
