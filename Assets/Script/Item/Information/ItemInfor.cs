using UnityEngine;

namespace Item.Information
{
    [System.Serializable]
    internal class ItemInformation
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string IDItem { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
