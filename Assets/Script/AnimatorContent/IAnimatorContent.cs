namespace AnimatorContent
{
    internal interface IAnimatorContent
    {
        UnityEngine.Animator Animator { get; }
        T GetAimatorComponet<T>() where T : AnimatorComponent;
        void AddAnimatorComponent(AnimatorComponent component);
    }
}
