using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achitecture.Entities
{
    internal abstract class EntityComponent : MonoBehaviour
    {
        public abstract void InitializationComponent(EntityController entityController);
    }
}
