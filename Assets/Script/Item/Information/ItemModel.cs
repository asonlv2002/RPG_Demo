using UnityEngine;
namespace Item.Information
{
    [System.Serializable]
    internal class ItemModel
    {
        [field : SerializeField] public GameObject Prefab { get; private set; }
        [field : SerializeField] public Mesh Mesh { get; private set; }
    }
}
