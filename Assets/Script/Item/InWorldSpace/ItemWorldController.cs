using Item.Information;
using UnityEngine;

namespace Item.InWorldSpace
{
    internal class ItemWorldController : MonoBehaviour
    {
        [field : SerializeField] public Information.ItemInformation Information { get; private set; }

        [SerializeField] MeshCollider meshCollider;

        public void OnCreate(ItemInformation information, ItemModel meshCollider)
        {
            Information = information;
            this.meshCollider = GetComponent<MeshCollider>();
            var item = Instantiate(meshCollider.Prefab);
            item.transform.SetParent(this.transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
        }
    }
}
