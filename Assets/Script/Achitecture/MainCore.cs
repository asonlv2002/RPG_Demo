namespace Achitecture
{
    using UnityEngine;
    using System.Collections.Generic;
    internal abstract class MainCores : MonoBehaviour
    {
        [SerializeField] List<Core> cores;
        public T GetCore<T>() where T : Core
        {
            foreach(var core in cores)
            {
                if (core is T)
                    return core as T;
            }
            return null;
        }

        public void AddCore(Core core)
        {
            cores.Add(core);
        }
    }
}
