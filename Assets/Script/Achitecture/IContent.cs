namespace Achitecture
{
    internal interface IContent<ComponentType>
    {
        T GetContentComponet<T>() where T : ComponentType;
        void AddContentComponent(ComponentType component);
    }
}
