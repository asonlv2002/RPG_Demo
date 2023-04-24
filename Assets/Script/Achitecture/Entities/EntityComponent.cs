using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achitecture.Entities
{
    internal abstract class EntityComponent : MonoBehaviour
    {
        protected EntityController _entityController;
        public virtual void InitializationComponent(EntityController entityController)
        {
            _entityController = entityController;
        }
    }
}
