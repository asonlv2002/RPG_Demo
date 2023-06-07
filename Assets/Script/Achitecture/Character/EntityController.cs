using UnityEngine;
using System.Collections.Generic;

namespace Achitecture.Entities
{
    internal abstract class EntityController : MonoBehaviour
    {
        [SerializeField] private List<EntityComponent> entityComponents;

        protected virtual void Awake()
        {
            this.InitializationComponent();
        }
        public T GetEntityComponent<T>() where T : EntityComponent
        {
            foreach(var component in entityComponents)
            {
                if(component is T) return (T)component;
            }

            return null;
        }

        protected void InitializationComponent()
        {
            foreach (var component in entityComponents)
            {
                component.InitializationComponent(this);
            }
        }
    }
}
