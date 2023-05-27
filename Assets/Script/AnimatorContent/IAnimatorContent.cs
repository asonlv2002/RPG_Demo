namespace AnimatorContent
{
    internal interface IAnimatorContent
    {
        T GetAimatorComponet<T>() where T : AnimatorComponent;

        void AddAnimatorComponent(AnimatorComponent component);
    }
}
