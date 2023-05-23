using UnityEngine;
namespace Item.ItemGameData
{
    class ItemDataContainer : MonoBehaviour
    {
        public static ItemDataContainer Intance;

        private void Awake()
        {
            Intance = this;
        }

    }
}
