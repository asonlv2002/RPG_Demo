using UnityEngine;
namespace Item.InEnviroment
{
    [System.Serializable]
    internal class ItemInEnviromentPrefab
    {
        [field : SerializeField] public ScytheInEnviroment ScythePrefab { get; private set; }
        [field : SerializeField] public BowInEnviroment BowPrefab { get; private set; }
    }
}
