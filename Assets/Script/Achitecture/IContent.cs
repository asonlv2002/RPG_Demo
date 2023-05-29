namespace Achitecture
{
    internal interface IContent<ComponentType>
    {
        T GetContentComponent<T>() where T : ComponentType;
        void AddContentComponent(ComponentType component);
    }
}
