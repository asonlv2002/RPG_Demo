using UnityEngine;

namespace Item.Information
{
    [System.Serializable]
    internal class ItemInformation
    {
        [field: SerializeField] public string Name { get; private set; }
        [SerializeField][TextArea] string _description; public string Description => _description;
        [field: SerializeField] public string IDItem { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
