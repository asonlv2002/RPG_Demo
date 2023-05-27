using UnityEngine;
namespace Item.ItemGameData
{
    internal class ItemDataContainer : MonoBehaviour
    {
        public static ItemDataContainer Intance;

        private void Awake()
        {
            Intance = this;
        }

    }
}
