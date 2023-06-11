using Item.ItemGameData;
using UnityEngine;
namespace Item.InEnviroment
{
    internal class ItemInEnviroment : MonoBehaviour, IItem, IItemCreateModel
    {
        [field : SerializeField] public ItemData ItemData { get; set; }

        public IItemRender ItemRenderModel { get; protected set; }


    }
}
