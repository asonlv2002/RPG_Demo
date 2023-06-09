namespace Achitecture
{
    using UnityEngine;
    using System.Collections.Generic;

    internal abstract class Core: MonoBehaviour
    {
        public MainCores MainCores { get; private set; }
        public virtual void InitMainCore(MainCores mainCores)
        {
            MainCores = mainCores;
        }

    }
    internal abstract class CoreContain<TypeCore> : Core where TypeCore : CoreComponent
    {
        protected List<TypeCore> CoreComponent = new List<TypeCore>();

        protected virtual void Awake()
        {
        }
        public T GetContentComponent<T>() where T : TypeCore
        {
            foreach (var component in CoreComponent)
            {
                if (component is T) return component as T;
            }
            return null;
        }
        public void AddContentComponent(TypeCore component)
        {
            CoreComponent.Add(component);
            component.OnAddComponent();
        }

        public void RemoveComponent<T>() where T : TypeCore
        {
            var component = CoreComponent.Find(x => x.GetType() == typeof(T));
            if (component != null)
            {
                component.OnRemoveComponent();
                CoreComponent.Remove(component);
                
            }

        }
    }
}
