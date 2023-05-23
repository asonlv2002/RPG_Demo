using Item.ItemGameData;
using UnityEngine;
namespace Item.InEnviroment
{
    internal abstract class ItemInEnviroment : MonoBehaviour, IItem, IItemCreateModel
    {
        public ItemData ItemData { get; set; }

        public IItemRender ItemRenderModel { get; protected set; }


    }
}
