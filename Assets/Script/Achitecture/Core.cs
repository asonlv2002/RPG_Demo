namespace Achitecture
{
    using UnityEngine;
    using System.Collections.Generic;

    internal abstract class Core: MonoBehaviour
    {
        protected MainCores MainCores;
        public virtual void InitMainCore(MainCores mainCores)
        {
            MainCores = mainCores;
        }

    }
    internal abstract class CoreContain<TypeCore> : Core where TypeCore : CoreComponent
    {
        protected List<TypeCore> CoreComponent;

        protected virtual void Awake()
        {
            CoreComponent = new List<TypeCore>();
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
        }

        public void RemoveComponent<T>() where T : TypeCore
        {
            var component = CoreComponent.Find(x => x.GetType() == typeof(T));
            if (component != null)
            {
                component.Remove();
                CoreComponent.Remove(component);
                
            }

        }
    }
}
